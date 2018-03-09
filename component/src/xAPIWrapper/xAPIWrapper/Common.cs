namespace xAPIWrapper
{
    internal static class Verbs
    {
        public const string ABANDONED = @"{
            'abandoned' : {
            'id' : 'https://w3id.org/xapi/adl/verbs/abandoned',
            'display' : {'en-US' : 'abandoned'}
            }";

        public const string ANSWERED = @"{
            'answered' : {
            'id' : 'https://w3id.org/xapi/adl/verbs/answered',
            'display' : {'de-DE' : 'beantwortete',
                         'en-US' : 'answered',
                         'fr-FR' : 'a répondu',
                         'es-ES' : 'contestó'}
             };

      //'asked' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/asked',
      //   'display' : {'de-DE' : 'fragte',
      //                'en-US' : 'asked',
      //                'fr-FR' : 'a demandé',
      //                'es-ES' : 'preguntó'}
      //},
      //'attempted' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/attempted',
      //   'display' : {'de-DE' : 'versuchte',
      //                'en-US' : 'attempted',
      //                'fr-FR' : 'a essayé',
      //                'es-ES' : 'intentó'}
      //},
      //'attended' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/attended',
      //   'display' : {'de-DE' : 'nahm teil an',
      //                'en-US' : 'attended',
      //                'fr-FR' : 'a suivi',
      //                'es-ES' : 'asistió'}
      //},
      //'commented' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/commented',
      //   'display' : {'de-DE' : 'kommentierte',
      //                'en-US' : 'commented',
      //                'fr-FR' : 'a commenté',
      //                'es-ES' : 'comentó'}
      //},
      //'completed' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/completed',
      //   'display' : {'de-DE' : 'beendete',
      //                'en-US' : 'completed',
      //                'fr-FR' : 'a terminé',
      //                'es-ES' : 'completó'}
      //},
      //'exited' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/exited',
      //   'display' : {'de-DE' : 'verließ',
      //                'en-US' : 'exited',
      //                'fr-FR' : 'a quitté',
      //                'es-ES' : 'salió'}
      //},
      //'experienced' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/experienced',
      //   'display' : {'de-DE' : 'erlebte',
      //                'en-US' : 'experienced',
      //                'fr-FR' : 'a éprouvé',
      //                'es-ES' : 'experimentó'}
      //},
      //'failed' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/failed',
      //   'display' : {'de-DE' : 'verfehlte',
      //                'en-US' : 'failed',
      //                'fr-FR' : 'a échoué',
      //                'es-ES' : 'fracasó'}
      //},
      //'imported' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/imported',
      //   'display' : {'de-DE' : 'importierte',
      //                'en-US' : 'imported',
      //                'fr-FR' : 'a importé',
      //                'es-ES' : 'importó'}
      //},
      //'initialized' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/initialized',
      //   'display' : {'de-DE' : 'initialisierte',
      //                'en-US' : 'initialized',
      //                'fr-FR' : 'a initialisé',
      //                'es-ES' : 'inicializó'}
      //},
      //'interacted' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/interacted',
      //   'display' : {'de-DE' : 'interagierte',
      //                'en-US' : 'interacted',
      //                'fr-FR' : 'a interagi',
      //                'es-ES' : 'interactuó'}
      //},
      //'launched' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/launched',
      //   'display' : {'de-DE' : 'startete',
      //                'en-US' : 'launched',
      //                'fr-FR' : 'a lancé',
      //                'es-ES' : 'lanzó'}
      //},
      //'mastered' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/mastered',
      //   'display' : {'de-DE' : 'meisterte',
      //                'en-US' : 'mastered',
      //                'fr-FR' : 'a maîtrisé',
      //                'es-ES' : 'dominó'}
      //},
      //'passed' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/passed',
      //   'display' : {'de-DE' : 'bestand',
      //                'en-US' : 'passed',
      //                'fr-FR' : 'a réussi',
      //                'es-ES' : 'aprobó'}
      //},
      //'preferred' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/preferred',
      //   'display' : {'de-DE' : 'bevorzugte',
      //                'en-US' : 'preferred',
      //                'fr-FR' : 'a préféré',
      //                'es-ES' : 'prefirió'}
      //},
      //'progressed' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/progressed',
      //   'display' : {'de-DE' : 'machte Fortschritt mit',
      //                'en-US' : 'progressed',
      //                'fr-FR' : 'a progressé',
      //                'es-ES' : 'progresó'}
      //},
      //'registered' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/registered',
      //   'display' : {'de-DE' : 'registrierte',
      //                'en-US' : 'registered',
      //                'fr-FR' : 'a enregistré',
      //                'es-ES' : 'registró'}
      //},
      //'responded' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/responded',
      //   'display' : {'de-DE' : 'reagierte',
      //                'en-US' : 'responded',
      //                'fr-FR' : 'a répondu',
      //                'es-ES' : 'respondió'}
      //},
      //'resumed' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/resumed',
      //   'display' : {'de-DE' : 'setzte fort',
      //                'en-US' : 'resumed',
      //                'fr-FR' : 'a repris',
      //                'es-ES' : 'continuó'}
      //},
      //'satisfied' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/satisfied',
      //   'display' : {'en-US' : 'satisfied'}
      //},
      //'scored' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/scored',
      //   'display' : {'de-DE' : 'erreichte',
      //                'en-US' : 'scored',
      //                'fr-FR' : 'a marqué',
      //                'es-ES' : 'anotó'}
      //},
      //'shared' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/shared',
      //   'display' : {'de-DE' : 'teilte',
      //                'en-US' : 'shared',
      //                'fr-FR' : 'a partagé',
      //                'es-ES' : 'compartió'}
      //},
      //'suspended' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/suspended',
      //   'display' : {'de-DE' : 'pausierte',
      //                'en-US' : 'suspended',
      //                'fr-FR' : 'a suspendu',
      //                'es-ES' : 'aplazó'}
      //},
      //'terminated' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/terminated',
      //   'display' : {'de-DE' : 'beendete',
      //                'en-US' : 'terminated',
      //                'fr-FR' : 'a terminé',
      //                'es-ES' : 'terminó'}
      //},
      //'voided' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/voided',
      //   'display' : {'de-DE' : 'entwertete',
      //                'en-US' : 'voided',
      //                'fr-FR' : 'a annulé',
      //                'es-ES' : 'anuló'}
      //},
      //'waived' : {
      //   'id' : 'https://w3id.org/xapi/adl/verbs/waived',
      //   'display' : {'en-US' : 'waived'}
      //}
      //}";
    }
}