# Coding

Every object will have these methods:
```csharp
public static void OnLoad()
{
	// Occurs when game is started and NOT loaded yet (unsafe)
}

public static void OnCreate()
{
	// Occurs when game is started and fully loaded (safe)
}

public static void OnDestroy()
{
	// Occurs when object is getting destroyed.
}

public static void OnAlarm()
{
	// Occurs when alarm is triggered.
}

public static void OnStep()
{
	// Occurs every step.
}

public static void OnCollision(string obj)
{
	// Occurs when object collides with a SOLID object.
}

public static void OnMeeting(string obj)
{
	// Occurs when object collides with an object.
}

public static void OnKeyPressed(EngineKey key)
{
	// Occurs when user pressed a key.
}

public static void OnMouseButtonPressed(EngineButton btn)
{
	// Occurs when user pressed a mouse button.
}

public static void OnPressed(EngineButton btn)
{
	// Occurs when user pressed a mouse button ON THIS OBJECT.
}
```

*SAFE* means that in this method you can do any API call.
*UNSAFE* means that in this method you can NOT do any API calls beacuse engine is not loaded yet.