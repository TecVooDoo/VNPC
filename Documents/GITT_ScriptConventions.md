# GITT Naninovel Script Conventions

## File Naming
- One file per GDD scene: `Scene1_1_HolographicHorse.nani`, `Scene2_3_TheWrongBaby.nani`, etc.
- Transition: `Transition.nani`
- Entry point: `GITT_Entry.nani`

## Character IDs (as registered in Naninovel)
- `Hanna` — protagonist
- `Mat` — antagonist
- `Nurse` — centaur nurse
- `Doctor` — centaur doctor

## Background IDs
- `Office` — Mat's executive office (Act 1)
- `OperatingRoom` — hospital OR with curtain up (Act 2)
- `OperatingRoomRevealed` — OR after curtain falls, centaur bodies visible (Act 2)
- `Black` — transitions, blackouts

## Dialogue Format
```nani
; Character dialogue — use character ID prefix
Hanna: This is dialogue spoken by Hanna.
Matt: This is dialogue spoken by Mat.

; Narration — no prefix (rendered as narrator text)
The room fell silent as Hanna considered his words.

; Internal monologue — italic via TMPro tags
<i>This can't be real.</i>
```

## Line Length
- Target 1-2 sentences per dialogue line (what fits in the text box)
- Break long speeches into multiple clicks
- Never exceed 3 sentences per line

## Stage Directions
```nani
; Character show/hide/move
@char Hanna pos:50             ; center
@char Hanna.Angry pos:30       ; left-ish, angry appearance
@char Matt pos:70              ; right-ish
@hide Hanna
@hide Matt

; Backgrounds
@back Office
@back Black time:1 wait!       ; fade to black over 1 second

; Pauses
@wait 0.5                      ; half-second pause for beats
```

## Character Positioning Guide
- Two characters talking: pos:30 and pos:70
- Single character centered: pos:50
- Three characters: pos:20, pos:50, pos:80

## Appearance Changes
- Change appearance inline: `@char Hanna.Angry`
- Default/neutral: `@char Hanna` (uses Element 0)

## Audio Placeholders (Phase 5)
```nani
; [Music: OfficeTension]       — will become @bgm OfficeTension
; [SFX: DeskSlap]              — will become @sfx DeskSlap
```

## Scene Linking
```nani
; End of each scene file:
@goto .NextScene               ; if using labels within same file
@goto ScriptName               ; jump to another .nani file
```

## Text Animator Effects (Phase 4)
- Effects will be added in Phase 4. For now, write clean dialogue.
- Planned tags: `<wave>`, `<shake>`, `<bounce>`, `<wiggle>`

## Special Characters
- Use actual Unicode: em dash (—), smart quotes (""), ellipsis (…), apostrophes (')
- TMPro renders these natively. Validated in Phase 0/1.

## Comments
```nani
; This is a comment — not displayed to player
; Use for stage direction notes, audio cues, pacing reminders
```

## Scene Header Template
```nani
; ============================================================
; Scene X.X — Scene Title
; ============================================================
; Location: Background name
; Characters: Who appears
; Summary: One-line description from GDD
; ============================================================
```
