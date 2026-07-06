using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstHost.Helpers
{
    public class SerialHelper
    {
        // ========== 1. 字段定义（硬件+控制） ==========
        private SerialPort _serialPort;          // 串口对象
        private CancellationTokenSource _cts;    // 取消令牌源（用于停止循环）
        private bool _isReading = false;         // 防止重复启动读取线程

        // ========== 2. 公开事件（供界面订阅） ==========
        public event EventHandler<string> DataReceived;  // 数据到达通知
        public event EventHandler<string> ErrorOccurred; // 错误通知（如端口断开）

        // ========== 3. 核心方法 ==========

        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open(string portName, int baudRate = 9600)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                Close(); // 如果已打开则先关闭
            }

            _serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            _serialPort.ReadTimeout = 500;  // 读取超时500ms，防止ReadLine卡死
            _serialPort.WriteTimeout = 500;
            _serialPort.DataReceived += SerialPort_DataReceived; // 订阅原生事件（备用）
            _serialPort.Open();
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            StopReading(); // 先停止后台循环

            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        /// <summary>
        /// 发送数据（字符串形式）
        /// </summary>
        public void SendData(string data)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                ErrorOccurred?.Invoke(this, "串口未打开，无法发送");
                return;
            }

            try
            {
                _serialPort.WriteLine(data); // 自动加换行符
                // 如果设备不需要换行，用 Write(data);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, $"发送失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 启动后台持续读取（替代原来的 StartSimulation）
        /// </summary>
        public void StartReading()
        {
            if (_isReading) return; // 防止重复启动

            _cts = new CancellationTokenSource();
            _isReading = true;

            Task.Run(() =>
            {
                try
                {
                    while (!_cts.IsCancellationRequested)
                    {
                        if (_serialPort == null || !_serialPort.IsOpen)
                        {
                            // 端口未打开，休息一下再检查
                            Thread.Sleep(200);
                            continue;
                        }

                        try
                        {
                            // ★★★ 核心：从真实串口读取一行数据 ★★★
                            string realData = _serialPort.ReadLine();

                            // 把真实数据通过事件传出去
                            DataReceived?.Invoke(this, realData);
                        }
                        catch (TimeoutException)
                        {
                            // 超时是正常现象（没数据来），什么也不做，继续循环
                        }
                        catch (Exception ex)
                        {
                            // 其他异常（比如拔掉USB），触发错误事件
                            ErrorOccurred?.Invoke(this, $"读取异常: {ex.Message}");
                            Thread.Sleep(1000); // 错误后暂停1秒，防止疯狂报错
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // 任务被取消，正常退出，不报错
                }
                finally
                {
                    _isReading = false;
                }
            }, _cts.Token);
        }

        /// <summary>
        /// 停止后台读取
        /// </summary>
        public void StopReading()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
            _isReading = false;
        }

        // ========== 4. 原生事件处理器（可选，用于被动接收） ==========
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 注意：这个事件是在子线程触发的，不能直接操作UI
            // 如果你不想用 StartReading 的循环，也可以在这里读数据
            // 但为了统一，我们优先用 StartReading 的主动读取方式
            // 这个方法留空，或者你可以在这里也触发 DataReceived
            // 注意：不要和 StartReading 重复触发，否则数据会显示两遍
        }

        // ========== 5. 检查串口是否打开 ==========
        public bool IsOpen
        {
            get { return _serialPort != null && _serialPort.IsOpen; }
        }
    }
}