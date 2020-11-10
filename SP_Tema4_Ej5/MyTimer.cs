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
        //Thread thPause;
        private bool isPaused = false;
        //private bool finished = false;
        Functions function;
        //Thread thRun;
        //Thread thPause;
        public bool acabo = false;
        public void run()
        {

            lock (l)
            {
                if (!acabo)
                {
                    isPaused = false;
                    Monitor.Pulse(l);
                }
            }

        }
        private void runMethod()
        {
            //while (!finished)
            //{
            while (!acabo)
            {
                if (!acabo)
                {
                    while (!isPaused)
                    {
                        lock (l)
                        {
                            function();
                        }
                        Thread.Sleep(interval);
                    }
                }
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
            
                lock(l){

                if (!acabo)
                    {
                        isPaused = true;
                    }
                }
            
        }

        /*private void aux()
        {
            lock (l)
            {
                while (!isPaused)
                {
                    Monitor.Wait(l);
                }
            }
        }*/

        public MyTimer(Functions func)
        {
            this.function = func;
            thRun = new Thread(runMethod);
            thRun.IsBackground = false;
            isPaused = true;
            thRun.Start();

            
            
        }
    }
}
