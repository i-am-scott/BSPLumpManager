# BSPLumpManager
This app allows you to select specific entities to be "split" into a lump file that is supported by most Source games. This allows you to send the 
edited bsp to your players while keeping the entity lump on the server. This means that you can keep parts of your map private.

It is recommended that you always keep the world entity inside the BSP. 
One example of a missing world entity on the client is no-collided rockets from the HL2 RPG.

To use simply run the application, load the target bsp and check any entity that you want to keep inside of the bsp (ie given to the client).
Pressing save lump will create a new lump file with every entity and a new bsp that contains the selected entities. If you rename the bsp make sure  you already rename the lmp file, keeping the _l_0 prefix.
