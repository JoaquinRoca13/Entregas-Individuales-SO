
public partial class Form1:Form
{
	Socket server;
	Thread atender;
	
	public Form1()
	{
		InitializeComponent();
	}
	private void Conectarbtn_Click(object sender, EventArgs e)
	{
		string mensaje = "1/"+nombreBox.text;
		byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
		server.Send(msg);
	}
	private void SaldoBtn_Click(object sender, EventArgs e)
	{
		string mensaje ="2/";
		byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
		server.Send(msg);
	}
	private void IngresoBtn_Click(object sender, EventArgs e)
	{
		string mensaje ="3/"+cantidad_i_Box.Text;
		byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
		server.Send(msg);	
	}
	private void CargoBtn_Click(object sender, EventArgs e)
	{
		string mensaje ="4/"+clienteBox.Text+"/"+cantidad_C_Box.Text;
		byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
		server.Send(msg);
	}
	private void ComisionBtn_Click(object sender, EventArgs e)
	{
		string mensaje = "5/"+comisonBox.Text;
		byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
		server.Send(msg);
	}
	private void EntrarBancoBtn_Click()
	{
		//al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("XXX");
            IPEndPoint ipep = new IPEndPoint(direc, 8007);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
				ThreadStart ts = delegate { AtenderServidor(); };
				atender = newThread(ts);
				atender.start();
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
	}
	private void AtenderServidor()
	{
		while(true)
		{
			int codigo
			byte msg = newbyte[80];
			server.Recive(msg);
			string mensaje = system.text.Encoding.ASCII.GetString(msg).Split('\0')[0];
			string trozos = mensaje.split('/');
			codigo = Convert.ToInt32(trozos[0]);
			switch(codigo){
				case 1:
					this.Invoke(new Action(()=>
					{
						respuestalbl.text = trozos[1];
					}));
					break;
				case 2:
					this.Invoke(new Action(()=>
					{
						notificacionlbl.text = "Se ha efectuado un cargo";
					}));
					break;
			}
		}
	}
}