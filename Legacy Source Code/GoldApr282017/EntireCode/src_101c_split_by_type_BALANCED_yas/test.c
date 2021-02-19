
main() 
{ int return_value;
  printf("The process id=%d / return value is %d\n\r", getpid(), return_value);
  printf("Forking process\n\r");
  fork();
  printf("The process id=%d / return value is %d\n\r", getpid(), return_value);
/*  execl("/bin/ls/","ls","-l",0);*/
  printf("This line is not printed\n\r");
}


