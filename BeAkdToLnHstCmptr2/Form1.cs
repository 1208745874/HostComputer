using BeAkdToLnHstCmptr2.Helpers; // 引用我们刚才写的工具类
using MyFirstHost.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace BeAkdToLnHstCmptr2
{
    public partial class Form1 : Form
    {
        private SerialHelper _helper = new SerialHelper();

        public Form1()
        {
            InitializeComponent();
            // 订阅事件
            _helper.DataReceived += Helper_DataReceived;
            _helper.ErrorOccurred += Helper_ErrorOccurred;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (btn_Connect.Text == "连接设备")
            {
                try
                {
                    // 假设下拉框选了 COM3，波特率 9600
                    string port = comboBox1.Text; // 你的端口下拉框
                    int baud = int.Parse(comboBox2.Text); // 波特率下拉框
                    _helper.Open(port, baud);
                    _helper.StartReading(); // 启动真实读取
                    btn_Connect.Text = "断开连接";
                    btn_Connect.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"打开失败: {ex.Message}");
                }
            }
            else
            {
                _helper.StopReading();
                _helper.Close();
                btn_Connect.Text = "连接设备";
                btn_Connect.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (!_helper.IsOpen)
            {
                MessageBox.Show("请先连接设备");
                return;
            }
            _helper.SendData(txt_Send.Text);
            txt_Send.Clear();
        }


        private void Helper_DataReceived(object sender, string data)
        {
            // 数据显示（必须 Invoke）
            txt_Receive.Invoke((MethodInvoker)delegate
            {
                txt_Receive.AppendText($"收到: {data}" + Environment.NewLine);
                txt_Receive.ScrollToCaret();
            });
        }

        private void Helper_ErrorOccurred(object sender, string errorMsg)
        {
            // 错误弹窗（必须 Invoke）
            txt_Receive.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(errorMsg, "串口错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Receive.AppendText($">>> 错误: {errorMsg}" + Environment.NewLine);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
