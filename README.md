Demonstrates a State pattern, where the logic for each state is encapsulated into its own class.

Transitions between states are managed by the following strategies:

CallbackToControllerStateTransitionStrategy:
The strategy is tightly coupled to the controller, in this case passed to it as a parameter from the state.
When a state requests a transition, a function is called on the controller object directly.
The controller uses a factory method on the enum to create a new instance of the desired state class.

RaiseEventStateTransitionStrategy:
To reduce the coupling between the states and controller, this strategy publishes an event without knowledge of its subscribers.
The controller subscribes to the event at construction by providing a callback function to the executed when the event is published.
The callback function then calls the function to change the state.
The controller uses a factory method on the enum to create a new instance of the desired state class.

EventAggregatorStateTransitionStrategy:
Rather than the controller subscribing directly to the state transition strategy, it subscribes to an event aggregation service. The event aggregation service
subscribes to the individual states and publishes them to the subscribers. This extra level of abstraction reduces the knowledge the controller has about how the source
of the events. A centralised aggregator class also facilitates extra features that may be required such as authentiation, recording and failure recovery mechanisms.
The controller uses a factory method on the enum to create a new instance of the desired state class.

SequentialStateTransitionStrategy:
All the state objects are provided to the controller via dependency injection using reflection to locate all objects that implement the ITestState interface.
When a state transition is requested, the controller changes its current state to the next state in the ordered list.