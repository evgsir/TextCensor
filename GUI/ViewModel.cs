using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Diagnostics.SymbolStore;
using System.Windows;
using Censor01;

namespace GUI;

public class ViewModel : INotifyPropertyChanged
{

    public ObservableCollection<string> Words { get; set; }

    private int countWords;
    private int countLetters;
    
    public int CountWords {
        get { return countWords;}
        set
        {
            countWords = value;
            OnPropertyChanged("CountWords");
        } }
    
    public int CountLetters {
        get { return countLetters;}
        set
        {
            countLetters = value;
            OnPropertyChanged("CountLetters");
        } }
    
  
    
    
    private string filePath = "";
    public string FilePath
    {
        get { return filePath;}
        set
        {
            filePath = value;
            OnPropertyChanged(FilePath);
        } }
    
    private RelayCommand censeFile;

    public RelayCommand CenseFile
    {
        get
        {
            return censeFile ??
                   (censeFile = new RelayCommand(obj =>
                       {
                           //MessageBox.Show(FilePath);
                           Information info = TextCensor.FileText(FilePath); 
                           Words.Clear();
                           foreach (var w in info.findWords)
                           {
                               Words.Add(w);
                           }
                           CountWords = info.findWords.Count;
                           CountLetters = info.countChangedLetters;
                       },
                       (o) => FilePath.Length > 0
                       ));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

   /* public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }*/

    public ViewModel()
    {
        Words = new ObservableCollection<string>();
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}