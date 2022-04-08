using TwinCAT.Ads;

namespace TwinCAT_C_Sharp_Tool
{
    public partial class Form1 : Form
    {
        public uint hVar;
        private AdsClient tcClient = new AdsClient();
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            tcClient.Connect("5.104.86.109.1.1",851);
            try
            {
                hVar = tcClient.CreateVariableHandle("MAIN.PLCVar");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // AdsStream which gets the data+
                byte[] array1 = new byte[100 * 2];
                AdsStream dataStream = new AdsStream(array1);
                BinaryReader binRead = new BinaryReader(dataStream);
                //read comlpete Array 
                tcClient.Read(hVar, array1);

                lbArray.Items.Clear();
                dataStream.Position = 0;
                for (int i = 0; i < 100; i++)
                {
                    lbArray.Items.Add(binRead.ReadInt16().ToString());
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}