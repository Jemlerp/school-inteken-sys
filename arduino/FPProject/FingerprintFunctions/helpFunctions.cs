using System.Collections.Generic;
using SourceAFIS.Simple;

namespace FFunc {
    public class helpFunctions {
        public static AfisEngine Afis = new AfisEngine();
        // Ok
        /// <summary>
        /// zoek voor van wie de vingerprint is
        /// </summary>
        /// <param name="allPersons">list of persons ( with fingerprinttemplate and id )</param>
        /// <param name="inFingerprintTemplate">fingerprint template</param>
        /// <returns></returns>
        public static int idOfPersonThatLooksLike(List<Person> allPersons, byte[] inFingerprintTemplate) {
            Person personToId = new Person();
            Fingerprint unknownFingerprint = new Fingerprint();
            unknownFingerprint.Template = inFingerprintTemplate;
            personToId.Fingerprints.Add(unknownFingerprint);
            foreach (Person person in allPersons) {
                float resValue = Afis.Verify(person, personToId);
                if (resValue >= 0) { return person.Id; }
            }
            return -420;
        }

    }
}
