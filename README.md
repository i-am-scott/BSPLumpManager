# BSPLumpManager
This app allows you to select specific entities to be "split" into a lump file that is supported by most Source games. This allows you to send the 
edited bsp to your players while keeping the entity lump on the server. This means that you can keep parts of your map private to hide easter eggs or cool concepts (meh).

It is recommended that you always keep the world entity inside the BSP or else every world brush will be seen as the Sky box which will cause issues with weapon bases and pretty much anything that relies on traces to check for world/skybox. One example of a missing world entity on the client is no-collided rockets from the HL2 RPG.

To use simply run the application, load the target bsp and check any entity that you want to keep inside of the bsp (ie given to the client).
Pressing save lump will create a new lump file with every entity and a new bsp that contains the selected entities. If you rename the bsp be sure to rename the lmp file, keeping the _l_0 suffix.
