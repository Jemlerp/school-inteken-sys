namespace FFunc {
    namespace WebSendAndReturnTypes {
        /// <summary>
        /// reading this value is faster than trying to cast to every type
        /// </summary>
        public interface IKnowType {
            string ThisType { get; }
        }

        /// <summary>
        /// send object to api with password
        /// </summary>
        public class TypeSendObjectWithPassword {
            public object typeWithOpdra { get; set; }
            public string password { get; set; }
        }

        /// <summary>
        /// returns the error that occurred
        /// </summary>
        public class TypeReturnError : IKnowType {
            public string ThisType { get { return "TypeReturnError"; } }
            public string why { get; set; }
        }

        /// <summary>
        /// ask the server to test sql connection
        /// </summary>
        public class TypeAskSqlConnection : IKnowType {
            public string ThisType { get { return "TypeAskSqlConnection"; } }
        }

        /// <summary>
        /// if the server can open a connection to the sql serever
        /// </summary>
        public class TypeReturnSqlConnection : IKnowType {
            public string ThisType { get { return "TypeReturnSqlConnection"; } }
            public bool canMakeConnectionToSqlServer { get; set; }
        }

        /// <summary>
        /// ask for id
        /// </summary>
        public class TypeAskID : IKnowType {
            public string ThisType { get { return "TypeAskID"; } }
            public string base64FingerprintTemplate { get; set; }
        }

        /// <summary>
        /// return id
        /// </summary>
        public class TypeReturnID : IKnowType {
            public string ThisType { get { return "TypeReturnID"; } }
            public string voorNaam { get; set; }
            public string achterNaam { get; set; }
            public int ID { get; set; }
            public string base64ProfileImage { get; set; }
        }

        /// <summary>
        /// new db entry
        /// </summary>
        public class TypeSendNewDBEntry : IKnowType {
            public string ThisType { get { return "TypeSendNewDBEntry"; } }
            public string VoorNaam { get; set; }
            public string AchterNaam { get; set; }
            public string Base64FingerprintTemplate { get; set; }
            public string Base64ProfileImage { get; set; }
        }

        /// <summary>
        /// return for when the DB is updated
        /// </summary>
        public class TypeReturnDBChanged : IKnowType {
            public string ThisType { get { return "TypeReturnDBChanged"; } }
            public int linesAffected { get; set; }
            public int idOfNewDBEntry { get; set; } // id of new person
        }

        /// <summary>
        /// update db
        /// </summary>
        public class TypeSendDBUpdate : IKnowType {
            public string ThisType { get { return "TypeSendDBUpdate"; } }
            public int WhereIDIs { get; set; }
            public bool deleteFromDB = false;
            public bool updateFingerprintTemplate = false;
            public string newBase64FingerprintTemplate { get; set; }
            public string newVoorNaam { get; set; }
            public string newAchterNaam { get; set; }
            public string newBase64ProfileImage { get; set; }
        }

        /// <summary>
        /// Get BD Entry (without fingerTemplate)
        /// </summary>
        public class TypeAskDBEntry : IKnowType {
            public string ThisType { get { return "TypeAskDBEntry"; } }            
            public bool dontUseWhereGetAll = false; // get all db entrys
            public string whereIdIs { get; set; }
            public bool getProfileImag { get; set; }
        }

        /// <summary>
        /// return for get BD Entry (een list van dit)
        /// </summary>
        public class TypeReturnDBEntry : IKnowType {
            public string ThisType { get { return "TypeReturnDBEntry"; } }
            public int ID { get; set; }
            public string voorNaam { get; set; }
            public string achterNaam { get; set; }
            public string base64profileImage { get; set; }
            // finger template is hidden
        }

    }
}
