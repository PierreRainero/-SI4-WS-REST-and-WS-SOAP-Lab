using System;
using System.Text;
using System.ServiceModel;

namespace EventsLib
{
    public class CalcService : ICalcService{
        static Action<int, double, double, double> m_Event1 = delegate { };
        static Action m_Event2 = delegate { };
        //Counter
        static int counter = 0;
        static Action<int> m_EventCounter = delegate { };

        public void SubscribeCalculatedEvent(){
            ICalcServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<ICalcServiceEvents>();
            m_Event1 += subscriber.Calculated;
        }

        public void SubscribeCalculationFinishedEvent(){
            ICalcServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<ICalcServiceEvents>();
            m_Event2 += subscriber.CalculationFinished;
        }

        public void Incr(){
            counter++;
            m_EventCounter(counter);
        }

        public void Decr(){
            counter--;
            m_EventCounter(counter);
        }

        public void SubscribeValueChanged(){
            ICalcServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<ICalcServiceEvents>();
            m_EventCounter += subscriber.ValueChanged;
        }

        public void Calculate(int nOp, double dblX, double dblY){
            double dblResult = 0;
            switch (nOp){
                case 0: dblResult = dblX + dblY; break;
                case 1: dblResult = dblX - dblY; break;
                case 2: dblResult = dblX * dblY; break;
                case 3: dblResult = (dblY == 0) ? 0 : dblX / dblY; break;
            }

            m_Event1(nOp, dblX, dblY, dblResult);
            m_Event2();
        }
    }
}