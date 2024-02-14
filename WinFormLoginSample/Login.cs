using System;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace WinFormLoginSample {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (IsAuthenticated(LdapLocation, $"{Domain}\\{txtAccount.Text}", txtPassword.Text, out string error)) {
                MessageBox.Show($"success to login {nameof(Domain)}: [{Domain}]");
                Hide();
                new MainForm().ShowDialog();
                Close(); // end of program
            } else
                MessageBox.Show($"fail to login {nameof(Domain)}: [{Domain}], reason: {error}");
        }

        private void Login_Load(object sender, EventArgs e) {
            // reference: https://stackoverflow.com/questions/1240373/how-do-i-get-the-current-username-in-net-using-c
            var userName = WindowsIdentity.GetCurrent().Name;
            var s = userName.Split('\\');
            txtAccount.Text = s.LastOrDefault();
            Domain = s.FirstOrDefault();
        }
        private string Domain { get; set; }
        /// <summary>
        /// TODO: fulfill ldap connection information as you know.
        /// </summary>
        private string LdapLocation { get; set; } = "";

        /// <summary>
        /// Login user with active directory
        /// </summary>
        /// <param name="srvr">ldap server, e.g. LDAP://domain.com</param>
        /// <param name="usr">user name</param>
        /// <param name="pwd">user password</param>
        /// <returns>authentication result, true for success, else false.</returns>
        /// <remarks>reference: https://stackoverflow.com/questions/290548/validate-a-username-and-password-against-active-directory</remarks>
        public static bool IsAuthenticated(string srvr, string usr, string pwd, out string error) {
            bool authenticated = false;
            error = null;
#if (DEBUG)
            return true;
#endif
            try {
                DirectoryEntry entry = new DirectoryEntry(srvr, usr, pwd);
                object nativeObject = entry.NativeObject;
                authenticated = true;
            } catch (Exception ex) {
                error = ex.Message;
            }

            return authenticated;
        }
    }
}
