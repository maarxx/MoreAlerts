# MoreAlerts

This is a mod for the game RimWorld by Ludeon Studios.

The mod offers more Alerts in the righthand sidebar that players might be interested in.

We're on Steam: https://steamcommunity.com/sharedfiles/filedetails/?id=2324527518

# Table of Contents

* [Introduction](#introduction)
* [Explanation](#explanation)

# Introduction

The mod offers more Alerts in the righthand sidebar that players might be interested in.

# Explanation

The mod provides more alerts, which are those lines on the right-hand side like "Minor break risk" or "Major break risk" or "Colonist needs rescue" or "Tattered clothing" or "Unhappy nudity".

Some of the new alerts include:

### Door Held Open
### Door Blocked Open
### Door Closed

The mod offers a Gizmo onto doors which allows you to set whether the door should normally be open or closed during routine base work time. Then, the mod will throw an alert if the door is in any other state, like if a dropped item blocked a door open, or if you held it open during combat and forgot to close it again.

### Pawns are Hot
### Pawns are Cold

These alerts literally follow whether the pawn's current instantaneous temperature is outside their comfort zone, considering their clothing.

### Slept in Heat
### Slept in Cold

These alerts follow the moodlet / thought, so this will persist as long as the moodlet / thought persists, which means it might linger for a little while longer after you fix the issue.

### Pawn is Restricted

This alert follows whether the Pawn's current Allowed Area is something other than "Unrestricted".

It also ignores zones named "Joy" or "ToxicH" for compatibility with my other mod [SmarterScheduling](https://github.com/maarxx/SmarterScheduling).

### Predator

This alert just tracks the total number of predators on your map, even if they haven't yet decided to hunt down and devour your loved ones.

It is useful for preemptively exterminating them.

### Rockets

This alert follows whether there are any hostile humanoids with rocket launchers (or prisoners, oops), and exactly how many.

### Downed Foreigner

Tracks downed pawns which are not your faction, everything from hostile raiders to traders to ally military aid. All people you want to either capture or rescue.

### Escaping Prisoners

This alert follows whether there any any escaping prisoners on your map, and how many.

This could be due to a Prison Break event, or just because some idiot left the door open.

Technically, it is prisoners "out of control", and also includes prisoners on mental breaks, even if they are still contained within a cell.

### Not Recruiting Prisoner

This alert tracks whether you have a prisoner lingering in your prison who is set to "No Interaction". Even if you didn't forget to recruit them, you probably at least want to set them to "Reduce Resistance" for free Warden training.

### Prisoner Break Risk

Tracks prisoners currently within range of Extreme mental break.

### Immunity Conditions

We look for pawns with health conditions with an Immunity component, and sort them by the Immunity/Severity differential, putting the most at-risk ones up top, and putting the top-most one right in the label text, so you don't forget.

### Fatal Conditions

This is like the above, but for Non-Immunity conditions, but which are still fatal at 100%. Think everything from Malnutrition to Heatstroke to Hypothermia to Blood Rot. We exclude Blood Loss, handled separately.

### Bleed Death

This tracks pawns who are bleeding, sorted by time to death. We put the worst one right in the label.

### Rest Until Healed

This alert helps you track whether you have any colonists you have instructed to prioritize "Rest Until Healed".

### Resting Break Risk

Pawns that are awake, and mobile, tend to take care of their Mood and Joy.

Pawns that are asleep have frozen Mood. They are no danger, but default alert "Break Risk" includes sleeping pawns, and so most players ignore this alert.

But pawns that are resting in bed for medical reasons, but not asleep, have nasty tendency to mental break, especially if they have overflowed your beautiful hospital into your awful bedrooms.

This alert tracks pawns that are resting, in bed, but not sleeping, who are break risks. Very useful.

### Building Damaged

Tracks buildings which are damaged, like walls hit by gunfire and stuff. Useful to know how much repair work you've got ahead of you. Sorts by %, worst one up top. Helpful to know which walls the sappers are going to come through.

### Want to Sleep With

This alert follows whether a pawn is suffering from negative thought about not being able to sleep with their lover or spouse.

### Constraining Clothes

This alert follows whether you forgot to tell any Nudists that they can take off their clothes now because the emergency is over.

### Untrashed Quest Expiring

If you have any quests expiring (timer to accept or timer to fail), it will post an alert with the shortest one, mouseover for all of them. If you don't want it here, then trashcan the quest, you can still do it or whatever.

### Fire Without Rain

Lists how many tiles of fire are on the entire map (not just Home area), but only if it isn't raining. Goes away when it begins to rain, comes back when rain is ending.

### Growing Zone Not Sowing

If you ticked a Growing Zone to disallow Sowing, that was probably temporary. Reminds you, so that you don't forget and run out of food.

### Forbidden Empty Hydroponics

If you ticked a Hydroponics to disallow Sowing, and it becomes empty, it reminds you to turn it back on.

### Thing Unpowered

This alert tracks whether a building on your map requires power and is currently unpowered. Good to know when your grid has been cut, or batteries/generators have run out.

### Wasting Psychic Helmet

Tracks that a pawn is wearing a Psychic Helmet, but there is no active event like Psychic Drone. Probably want to take it off for now.

### Unused Resource Permits

Some Royalty Permits, like Steel Drop / Food Drop / Glittermed Drop / etc, are just free resources, and you want to use them as soon as they become available, every time, and not using them is just wasting them. Alerts you that one has come off cooldown.

### Unused Morale Guide Ability

If your Ideology's Morale Guide's ability is ready, show an alert to remind you to use it.

### Anytime Festival Ready

If you have an Ideology Festival with anytime start that is totally off cooldown and no diminishing return, post an alert to remind you to use it.
