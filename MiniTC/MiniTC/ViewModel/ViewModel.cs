using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MiniTC.Model;

namespace MiniTC.ViewModel
{
    class ViewModel : ViewModelBase
    {
        #region fields
        Model.Model MODEL = new Model.Model();
        #endregion


        public ViewModel()
        {
            CopyDriveList = MODEL.GetDrives();
            PasteDriveList = MODEL.GetDrives();

        }

        #region indexes
        private int copyComboIndex = -1;
        public int CopyComboIndex
        {
            get
            {
                return copyComboIndex;
            }
            set
            {
                copyComboIndex = value;
                CopyPath = CopyDriveList[copyComboIndex];
                CopyFilesList = MODEL.GetFiles(CopyPath);
                onPropertyChanged(nameof(copyComboIndex));
            }
        }
        private int pasteComboIndex = -1;
        public int PasteComboIndex
        {
            get
            {
                return pasteComboIndex;
            }
            set
            {
                pasteComboIndex = value;
                PastePath = PasteDriveList[pasteComboIndex];
                PasteFilesList = MODEL.GetFiles(PastePath);
                onPropertyChanged(nameof(PasteComboIndex));
            }
        }
        private int copyListIndex = -1;
        public int CopyListIndex
        {
            get
            {
                return copyListIndex;
            }
            set
            {
                copyListIndex = value;
                onPropertyChanged(nameof(CopyListIndex));
            }
        }
        private int pasteListIndex = -1;
        public int PasteListIndex
        {
            get
            {
                return pasteListIndex;
            }
            set
            {
                pasteListIndex = value;
                onPropertyChanged(nameof(PasteListIndex));
            }
        }
        #endregion

        #region textPath
        private string copyPath;
        public string CopyPath
        {
            get
            {
                return copyPath;
            }
            set
            {
                copyPath = value;
                CopyFilesList = MODEL.GetFiles(CopyPath);
                onPropertyChanged(nameof(CopyPath));
            }
        }

        private string pastePath;
        public string PastePath
        {
            get
            {
                return pastePath;
            }
            set
            {
                pastePath = value;
                PasteFilesList = MODEL.GetFiles(PastePath);
                onPropertyChanged(nameof(PastePath));
            }
        }
        #endregion

        #region driveCombo 
        private string[] copyDriveList;
        public string[] CopyDriveList
        {
            get
            {
                return copyDriveList;
            }
            set
            {
                copyDriveList = value;
                onPropertyChanged(nameof(PasteDriveList));
            }
        }
        private string[] pasteDriveList;
        public string[] PasteDriveList
        {
            get
            {
                return pasteDriveList;
            }
            set
            {
                pasteDriveList = value;
                onPropertyChanged(nameof(PasteDriveList));
            }
        }
        #endregion

        #region pathList
        private string[] copyFilesList;
        public string[] CopyFilesList
        {
            get
            {
                return copyFilesList;
            }
            set
            {
                copyFilesList = value;
                onPropertyChanged(nameof(CopyFilesList));
            }
        }
        private string[] pasteFilesList;
        public string[] PasteFilesList
        {
            get
            {
                return pasteFilesList;
            }
            set
            {
                pasteFilesList = value;
                onPropertyChanged(nameof(PasteFilesList));
            }
        }
        #endregion

        private ICommand copyFile = null;
        public ICommand CopyFile
        {
            get
            {
                if (copyFile == null)
                {
                    copyFile = new RelayCommand(
                        x =>
                        {
                            //Debug.WriteLine("index: "+ CopyListIndex);
                            //Debug.WriteLine("len: " + CopyFilesList.Length);
                            bool tmp = MODEL.CopyFile(CopyFilesList[CopyListIndex], pastePath);
                            if (tmp)
                            {
                                Debug.WriteLine("jestem");
                                CopyFilesList = MODEL.GetFiles(CopyPath);
                                PasteFilesList = MODEL.GetFiles(PastePath);
                            }
                        },
                        x =>
                        {
                            if (CopyFilesList == null)
                            {
                                return false;
                            }
                            if (CopyListIndex < CopyFilesList.Length && CopyListIndex > -1)
                            {
                            return true;
                            }

                            return false;
                        }
                        );

                }
                return copyFile;
            }
        }
    }
}
