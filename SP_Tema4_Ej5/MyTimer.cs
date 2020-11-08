using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SP_Tema4_Ej5
{
    public delegate void Functions();


    class MyTimer
    {
        public int interval;
        static object l = new object();
        Thread thRun;
        Thread thPause;
        private bool isPaused = false;
        private bool finished = false;
        Functions function;
        //Thread thRun;
        //Thread thPause;
        public void run()
        {
            thRun = new Thread(runMethod);
            thPause = new Thread(aux);
            isPaused = false;
            thRun.Start();

        }
        private void runMethod()
        {
            //while (!finished)
            //{
                while (!isPaused)
                {
                    lock (l)
                    {
                        function();
                    }
                    Thread.Sleep(interval);
                    
                }

                /*while (isPaused)
                {
                    Monitor.Pulse(l);
                }*/
                    //Monitor.Wait(l);
            //}
        }

        public void pause()
        {
            isPaused = true;
        }

        private void aux()
        {
            lock (l)
            {
                while (!isPaused)
                {
                    Monitor.Wait(l);
                }
            }
        }

        public MyTimer(Functions func)
        {
            this.function = func;
            
            
        }
    }
}
