
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
ListaClientes milistaclientes;

void *AtenderCliente(void *Socket){
char peticion[200];
char notificacion[200];
char respuesta[200];
	int ret;
	
	char nom[20];
	int sock_conn = *(int *socket)
	int terminar=0;
	while(!terminar) {
		ret = read(sock_conn,peticion,sizeof(peticion));
		peticion[ret]=”0\”;
	
		char *p = strtok(peticion, “/”);
		int codigo  = atoi(p);
		if(codigo==0){
		//Desconexió 
	
pthread_mutex_lock(&mutex);
TomarNotaClienteDesconectado(&milistaclientes,sock_conn);
	pthread_mutex_unlock(&mutex);
	terminar = 1;
}
else if(codigo == 1){
	p=strtok(NULL,”/”);
	strcpy(nom,p);
	pthread_mutex_lock(&milistaclientes,nom,sock_conn);
	pthread_mutex_unlock(&mutex);
}
else if(codigo ==2){
	int saldo = DameSaldoCliente(&milistaclientes,nom);
	sprintf(respuesta,”1/%d”,saldo);
	write(sock_conn,respuesta);
}
else if(codigo==3){
	p=strtok(NULL,”/”);
	int cantidad = atoi(p);
	pthread_mutex_lock(&mutex);
	HacerIngreso(&milistaclientes,nom);
	pthread_mutex_unlock(&mutex);
}
else if(codigo==4){
	p=strtok(NULL,”/”);
	char cliente[20];
strcpy(cliente,p);
	p=strtok(NULL,”/”);
	int cargo = atoi(p);
	pthread_mutex_lock(&mutex);
	HacerCargoCliente(&milistaclientes,cargo,cliente);
	pthread_mutex_unlock(&mutex);
}
else if(codigo==5){
	p=strtok(NULL,”/”);
	int comision = atoi(p);
	pthread_mutex_lock(&mutex);
	HacerComision(&milistaclientes,comision);
	pthread_mutex_unlock(&mutex);

	int conectados = DameSocketsConectados(&milistaclientes,socket);
	strcpy(notificacion,”2/”);
	for(int i=0;i<num;i++)
		write(sockets[i].notificacion,strlen(notificacion));
}

}
	
Close(sock_conn);
}//AtenderCliente
