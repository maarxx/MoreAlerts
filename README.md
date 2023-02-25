# MoreAlerts

This is a mod for the game RimWorld by Ludeon Studios.

It offers more Alerts in the righthand sidebar that players might be interested in.

We're on Steam: https://steamcommunity.com/sharedfiles/filedetails/?id=2324527518

# Table of Contents

* [Introduction and Explanation](#introduction-and-explanation)
* [How to Install](#how-to-install)
* [How to Update](#how-to-update)
* [Bugs, New Features, and Updates](#bugs-new-features-and-updates)

# Introduction and Explanation

You'll add the mod. You'll enable the mod. It will immediately start working.

There is no interface or configuration options. If you don't like it, turn the mod off again.

The mod provides more alerts, which are those lines on the right-hand side like "Minor break risk" or "Major break risk" or "Colonist needs rescue" or "Tattered clothing" or "Unhappy nudity".

Some of the new alerts include:

### Pawns are Hot
### Pawns are Cold

These alerts literally follow whether the pawn's current instantaneous temperature is outside their comfort zone, considering their clothing.

### Slept in Heat
### Slept in Cold

These alerts follow the moodlet / thought, so this will persist as long as the moodlet / thought persists, which means it might linger for a little while longer after you fix the issue.

### Door Held Open
### Door Blocked Open

These are two separate alerts, which, respectively, keep track of Doors which are marked as "Hold Open", and doors which are blocked open, probably because somebody dropped an item in the doorway.

### Pawn is Restricted

This alert follows whether the Pawn's current Allowed Area is something other than "Unrestricted".

It also ignores zones named "Joy" or "ToxicH" for compatibility with my other mod [SmarterScheduling](https://github.com/maarxx/SmarterScheduling).

### Animal Hunting

This alert follows whether a wild animal is hunting one of your faction members (human or animal), either because it is a hungry predator or because it has gone manhunter.

During manhunter events, it also conveniently tells you exactly how many manhunter animals are left.

### Predator

This alert just tracks the total number of predators on your map, even if they haven't yet decided to hunt down and devour your loved ones.

It is useful for preemptively exterminating them.

### Mechanoids

This alert follows whether there are any mechanoids on your map, and exactly how many.

## Insects

This alert follows whether there are any insects on your map, and exactly how many.

### Raiders

This alert follows whether there are any hostile humanoid raiders on your map, and exactly how many.

### Rockets

This alert follows whether there are any hostile humanoids with rocket launchers (or prisoners, oops), and exactly how many.

### Hostile Non-Hostiles

This alert follows whether there are hostile things on your map that aren't normally a hostile faction. Tracks everything affected by Berserk or Neuroquake, etc, regardless of faction.

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

### Downed Foreigner

Tracks downed pawns which are not your faction, everything from hostile raiders to traders to ally military aid. All people you want to either capture or rescue.

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

# How to Install

At the top of this page, on the right-hand-side, a little ways down, will be a green button, labeled "Clone or download". Click it, then click "Download ZIP". Your browser will download it.

Unzip it, and it will spew out a single folder, which is probably named something like `MoreAlerts-master`.

Assuming you are working with default installation directories on a Windows system, you will want to move this entire folder into:

`C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods`

If you did it correctly, the result should be a directory structure that looks something like this:

`C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\MoreAlerts-master\Assemblies`

Then restart RimWorld and enable it like any other mod.

# How to Update

First and foremost, please note that I never test updating mods on older saved games. You can try it, but please assume that a new game might always be necessary.

I also don't explicitly test whether the mod can be disabled on an existing game. Please also assume that a new game might always be necessary.

With that out of the way:

Updating is just deleting the previous version of the mod and then installing a new version.

So again, assuming default installation directories on a Windows system, you'll want to delete the same folder that you added during installation, which probably looks something like:

`C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\MoreAlerts-master`

Then follow the previous instructions to download and install the new version, by repeating the same steps as installing the original version.

# Bugs, New Features, and Updates

You are currently looking at a GitHub repository for managing application code. I work out of this GitHub repository, and so to talk about bugs, new features, or updates, you need to know a little bit about navigating a GitHub repository like this one.

Beneath the aforementioned green button "Clone or download", it will say "Latest commit", followed by a couple random characters, followed by an amount of time. This stamp indicates how long ago the mod was last updated.

So if you think you found a problem, check this stamp. Perhaps the mod has already been updated since you downloaded it last, and you should download a new version and update. See the above instructions for how to update.

By default, you are probably looking at the "master" branch. You can see this at the top of the page, on the left-hand-side, a little ways down, it will say "Branch: something", probably "Branch: master", with a little down arrow.

The "master" branch contains the current version of the mod which I consider to be tested and stable. Mostly. I guess.

Most (but not all) of my mods have a "beta" branch for pre-release, which might offer new features or bug fixes that should probably work, theoretically, but I haven't really done much testing on, so I'm not quite sure.

So if you tried updating from the "master" branch, and you still think you found a bug or a problem, or if you just want to try the shiny new features before everybody else, consider downloading the "beta" branch and installing that instead.

To do this, just click the button where it says "Branch: master", and then click the option for "beta". Congratulations! You've changed branches! Follow the same steps to download and install, except instead of `MoreAlerts-master` it will now be `MoreAlerts-beta`. You can have both versions installed, but please don't try to have both versions enabled at once using the in-game Mod menu.

You will probably see other choices besides "master" and "beta", but I don't recommend clicking them. I am probably in the middle of working on them, and they are probably only halfway done, and broken, otherwise they'd already be part of "beta".

So if you tried updating the master branch, and you tried the beta branch, and you still thing you found a bug, or a problem, or want to suggest a new feature, wander over to the "Issues" tab. You can find this at the very top of the page, you are currently on the first tab "Code", you want to change to the second tab "Issues".

You can look here to see if your bug, issue, or suggestion is already present, and add comments if you wish.

If it's not there, look to the right-hand-side, click the green button "New issue", just type a Title, and Leave a comment, and then look below and click the green button "Submit new issue". I will get back to you. Maybe. Eventually. Meanwhile, other users might be able to chime in and help you too!
