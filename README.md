# A sample to show windows form login with **Active Directory**
 A WinForm login sample with AD authentication

This sample was required for friends.

Run it on your own, you have to provide LDAP location in your environment. Here is a TODO you have to.

In *Login.cs*, 
``` csharp
/// <summary>
/// TODO: fulfill ldap connection information as you know.
/// </summary>
private string LdapLocation { get; set; } = "";
```
Fill the real location here, and remove the fake login between **if(DEBUG) ... #endif** statement:

```csharp
        public static bool IsAuthenticated(string srvr, string usr, string pwd, out string error) {
            bool authenticated = false;
            error = null;
#if (DEBUG)
            return true;
#endif
            try {

```

```mermaid
graph LR
    0((start)) --> 1(Program)
    subgraph WinForm Application
        1 -->
        A(Login) -->
        B(Main)
    end
    B --> 99((end))
```
Try as you need.

