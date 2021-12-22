using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserInterfaceWPF.Tools {
    /*
     * 
     *  
     * Extra klasse aangemaakt die de navigatie regelt aan de hand van een c# collectie => Stack
     * 
     * 
     * Stack.NavigateTo() => Next window
     * 
     * Stack.NavigateBack() => Previous window
     */
    public static class StackService {

        static StackService() {
            NavigationStack.Push(Application.Current.MainWindow);
        }

        private static readonly Stack<Window> NavigationStack = new Stack<Window>();

        public static void NavigateTo(Window win) {
            if (NavigationStack.Count > 0)
                NavigationStack.Peek().Hide();

            NavigationStack.Push(win);
            win.Show();
        }

        public static bool NavigateBack() {
            if (NavigationStack.Count <= 1)
                return false;

            NavigationStack.Pop().Hide();
            NavigationStack.Peek().Show();
            return true;
        }

        public static bool CanNavigateBack() {
            return NavigationStack.Count > 1;
        }
    }
}
