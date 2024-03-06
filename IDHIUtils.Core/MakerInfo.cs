//
// MakerInfo
//
/*
To comply with this rule, elements at the file root level or within a namespace should be
positioned in the following order:

Extern Alias Directives
Using Directives
Namespaces
Delegates
Enums
Interfaces
Structs
Classes


Within a class, struct or interface: (SA1201 and SA1203)

Constant Fields
Fields
Constructors
Finalizers (Destructors)
Delegates
Events
Enums
Interfaces (interface implementations)
Properties
Indexers
Methods
Structs
Classes

Within each of these groups order by access: (SA1202)

public
internal
protected internal
protected
private

Within each of the access groups, order by static, then non-static: (SA1204)

static
non-static

Within each of the static/non-static groups of fields, order by readonly,
then non-readonly : (SA1214 and SA1215)

readonly
non-readonly

public static methods
public methods
internal static methods
internal methods
protected internal static methods
protected internal methods
protected static methods
protected methods
private static methods
private methods

The documentation notes that if the prescribed order isn't suitable - say, multiple
interfaces are being implemented, and the interface methods and properties should be
grouped together - then use a partial class to group the related methods and properties
together.
 */
// Ignore Spelling: Utils

using UnityEngine.SceneManagement;


namespace IDHIUtils
{
    // Can Identify if the maker been used is called from the room or the title screen
    public partial class MakerInfo
    {
        #region Properties
        public static bool TitleRoot { get; private set; } = false;
        public static bool ActionRoot { get; private set; } = false;
        public static bool InMaker { get; private set; } = false;
        public static bool InRoomMaker { get; private set; } = false;
        #endregion

        #region public Methods
        public static void Init()
        {
            SceneManager.sceneLoaded += SceneLoaded;
            SceneManager.sceneUnloaded += SceneUnloaded;
        }
        #endregion

        #region private Methods
        private static void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Title")
            {
                TitleRoot = true;
                ActionRoot = false;
            }
            if (scene.name == "Action")
            {
                ActionRoot = true;
                TitleRoot = false;
            }
            if (scene.name == "CustomScene")
            {
                InMaker = TitleRoot;
                InRoomMaker = ActionRoot;
            }
        }

        private static void SceneUnloaded(Scene scene)
        {
            if (scene.name == "CustomScene")
            {
                InMaker = false;
                InRoomMaker = false;
            }
        }
        #endregion
    }
}
