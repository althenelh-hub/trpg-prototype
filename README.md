This scripts are defining a fucntionality of the player phase.

Player's units control
  - all player's control modes are separated in different states of the game, which are imlplementing methods for input processing. This way when player is
    controlling units skill menu, the unit themselve won't move on the map (separation of the input).
  - cursor movement;
  - constraining cursor movement to the level boundaries;
  - chosing unit for movement;
  - display units movement range;
  - constraining cursor movement to the units movement range after chosing unit;
  - canceling unit selection;
  - moving unit to the specified place;
  - canceling units movement and returning to the unit chosing mode
  - displaying skill selection menu;
  - canceling skill selection and returning unit to its starting position;
  - chosign available to the unit skill;
  - displaing sklls zone of effect/available targets;
  - canceling skill and returning to skill choice menu;
  - moving zone of effect / change selected target for skill;
  - confirm skill usage and return to unit select mode;
  - deactivation of unit;
  - end of the phase by making action with all units.

Skill effect:
  - algorythms of raster graphics are used to display differnt forms of skill's zone of effects.
  - check for needed resources(weapon, stamina, enemy perception) before activating skill;
  - confirmation of characters death and applying it on the level;
  - performing skill effects like pushing enemy on next tile and applying it to the level;
  - three skill control modes: radius of effect, direction of effect, target select;
  - Skills with radius of effect, player can control by moving its radius on the map, skill will apply to every unit in zone of effect;
  - skill with direction of effect, player can control by changing the direction of skill zone(north, south, west, east),
    skill will apply to every unit in zone of effect;
  - Skills with taret select, player can control by chosing the target in the radius of the skill effect (available targest are highlighted), units which are
    behind obstacles or units are unavailable for attack (and not highlighted).
  - For creating different types of unique skills, there were created skill effect class, which contains the effect themselve (deal damage, move enemy). This
    way it is possible to customize skills without creating difficult hierachies of inheritance.
    
Level effects:
  - terrain effects. Terrains like forest cost to movement points to move unit through it. Tearrin effects are realised by using table of terrain -> penalty. This
    way it is possible to avoid storing penalty value in every tile object on the map optimising memory usage. 
