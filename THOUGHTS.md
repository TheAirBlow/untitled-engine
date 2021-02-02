# Coding

Every object will have these methods:
```csharp
// This will be called when object is created
public static void Start()
{
	
}

// This will be called every update
public static void Update()
{
	
}

// This will be called when object is destroyed
public static void OnDestroy()
{
	
}

// This will be called when colliding with a solid object
public static void OnCollision(string obj)
{
	
}

// This will be called when colliding with any object
public static void OnMeeting(string obj)
{
	
}
```

# APIs
```csharp
// Start an alarm with a delay
void alarm(0)

// Get current alarm state
bool alarm()

// Move object by X
void move_x(0)

// Move object by Y
void move_y(0)

// Move object by both axis
void move(0, 0)

// Move object by X on pos
// m, x
void move_x(0, 0)

// Move object by Y on pos
// m, y
void move_y(0, 0)

// Move object by both axis on pos
// m, x, y
void move(0, 0, 0)

// Destroy an object on pos
void destroy(0, 0)

// Is key pressed
bool is_pressed_keyboard(key)

// Is mouse button pressed
bool is_pressed_mouse(key)

// Is object clicked
bool is_clicked()

// Play a sound
void snd_play("hello")
```