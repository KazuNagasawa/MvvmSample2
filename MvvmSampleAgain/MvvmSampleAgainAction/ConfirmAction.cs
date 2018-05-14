using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace MvvmSampleAgainAction
{
    public class ConfirmAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            //イベント引数となるContextを取得する
            var args = parameter as InteractionRequestedEventArgs;
            var confirmation = args.Context as Confirmation;

            //MessageBoxを表示する
            MessageBox.Show(confirmation.Content as string,
                confirmation.Title as string,
                MessageBoxButton.OK);
        }
    }
}
 
