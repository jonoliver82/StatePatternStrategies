## C# State Patterns

The logic for each state is encapsulated into its own class.
The controller uses a factory method on the enum to create a new instance of the desired state class.

### CalbackStatePattern
The state object calls the controller service function directly indicating the state that it should transition to.
The state and controller and tightly coupled, as the state uses a reference to the controller passed to the function. 
Alternatively this could be provided by dependency injection into the state constructor.

### Event Aggregator Pattern
The state object publishes an event to a central event aggregator requesting a state transition.
The controller subscribes to the event aggregator for state transition event requests.
This extra level of abstraction reduces the knowledge the controller has about how the source of the events. 
A centralised aggregator class also facilitates extra features that may be required such as authentiation, recording and failure recovery mechanisms.

### Raise Event Pattern
To reduce the coupling between the states and controller, the state publishes an event without knowledge of its subscribers.
The state object publishes an event to its direct subscribers requesting a state transition.
The controller subscribes directly to the state object for the event.

### Sequential Pattern
All the state objects are provided to the controller via dependency injection using reflection to locate all objects that implement the ITestState interface.
The state object calls the controller service function directly to request transition to the next ordered state.
Additional states can be introduced without changing the controller or factory code.