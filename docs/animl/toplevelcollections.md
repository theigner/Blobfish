# Top level collections of an AnIML document

Collections of elements in AnIML documents are named `<CollectionType>Set` (the suffix `Set` is added to the name of the collection type). Those collections contain elements of type `CollectionType` but can also contain additional elements and collections of other types.

The AnIML core schema defines four collections as top level elements:

1. `SampleSet`  
A collection of samples with various properties and metadata.

2. `ExperimentStepSet`  
A collection of experiment steps that contain data and results for experiments. Relations between samples and experiments as well as between multiple experiments are defined within this collection (to be precise those relations are defined in the `Infrastructure` property of an `ExperimentStep`).

3. `AuditTrailEntrySet`  
A collection of audit trail entries that describe the operations performed on the AnIML document.

4. `SignatureSet`  
A collection of digital signatures following the XML-DSig standard used to ensure the integrity of the AnIML document.
