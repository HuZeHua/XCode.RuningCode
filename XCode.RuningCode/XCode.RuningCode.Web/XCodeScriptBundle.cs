using System.Web.Optimization;

namespace XCode.RuningCode.Web
{
    public class XCodeScriptBundle : ScriptBundle
    {
        readonly JavascriptObfuscator _jso = new JavascriptObfuscator();

        public XCodeScriptBundle(string virtrualPath)
            : base(virtrualPath)
        {
            Transforms.Add(_jso);
        }
    }
}