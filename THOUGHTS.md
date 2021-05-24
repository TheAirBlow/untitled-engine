# Coding

Every object will have these methods:
```
# This will be called when object is created
event create begin

end

# This will be called every update
event update begin

end

# This will be called when object is destroyed
event destroy begin

end

# This will be called when colliding with a solid object
# c_obj is object
event collision args c_obj begin

end

# This will be called when colliding with any object
# m_obj is object
event meeting args m_obj begin

end
```

# APIs
```
# Start an alarm with a delay
method alarm 0 0

# Move object by X
method movex 0

# Move object by Y
method movey 0

# Move object by both axis
method move 0 0

# Destroy an object
method destroy 

# Is key pressed
input keyboard_pressed 'x'

# Is mouse button pressed
input mouse_pressed 0

# Get mouse X
input mouse_x

# Get mouse Y
input mouse_y

# Play a sound
input sound_play 'hello'

# Play a sound repeating
input sound_play_repeat 'hello'

# Stop a sound
input sound_stop 'hello'
```
