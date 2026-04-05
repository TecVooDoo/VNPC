# Encapsulated Fear -- Game Design Document

**Developer:** TecVooDoo LLC
**Type:** Visual Novel
**Stack:** Naninovel + Text Animator (+ Dialogue System for shared logic)
**Source:** "Encapsulated Fear: A Short Tail" short story (~7,600 words)
**Origin:** Written to make the author's wife laugh while she was on steroids for a serious medical condition. Characters are absurdly exaggerated versions of the author, his wife, two of their sons, and their real dog. Wife recovered and encouraged turning it into a proper short story. No formal outline -- grew organically from real life.
**Dev Priority:** 2 (second VN to develop, after GITT)
**Estimated Playtime:** 45-75 minutes

**Document Version:** 0.1
**Last Updated:** February 21, 2026

---

## Table of Contents

1. [Overview](#overview)
2. [Story Summary](#story-summary)
3. [Characters](#characters)
4. [Locations](#locations)
5. [Scene Breakdown](#scene-breakdown)
6. [Art Requirements](#art-requirements)
7. [Audio Requirements](#audio-requirements)
8. [UI/UX Notes](#uiux-notes)
9. [Design Decisions](#design-decisions)

---

## 1. Overview

### Premise

A middle-aged husband journals what he believes are his final days after his wife begins a new steroid medication. The insert says "mood changes." His mother-in-law warned him. He is convinced this pill will transform his wife into a literal monster -- and he documents everything with overwrought, paranoid melodrama.

### Tone

Comedy first. Dark humor, dramatic irony, self-deprecating narration. The narrator is an unreliable, lovably ridiculous man who describes mundane domestic life as a survival-horror scenario. Think Clue meets Edgar Allan Poe meets a dad blog.

### Themes

- Marriage as a comedic battlefield
- Paranoia vs reality (unreliable narrator)
- Domestic life as epic saga
- The absurdity of masculine bravado
- Love expressed through ridiculousness

### Setting

Contemporary suburban home. Completely ordinary -- the horror is entirely in the narrator's head (mostly). Bedroom, backyard, kitchen, bathroom.

---

## 2. Story Summary

The narrator discovers his wife has been prescribed a corticosteroid. The medication insert warns of "mood changes," and her mother confirms she became "an absolute monster" on it as a child. Convinced this pill will literally transform his wife into a creature, the narrator begins journaling his experience -- framing himself as the noble hero documenting humanity's last hope.

Over three days, he: measures his sleeping wife with a tape measure at 3am (to check if she's grown), hides behind a tree in the backyard to spy on her (concluding his children are now mind-controlled thralls), calls his mother-in-law at 3am to interrogate her about pillows (which he believes are soundproofing for his future screams), performs an elaborate coffee ritual, and ultimately arms himself with a bath bomb for the final confrontation.

**Twist:** His wife never took the steroid -- it was an aspirin ("You tend to give me a headache"). But she does, in fact, have a blood-red spork-shaped tail. She's been a monster all along. "You were right."

---

## 3. Characters

### The Narrator / Husband (Protagonist)

- **Role:** Player-perspective character, first-person journal narration
- **Age:** Middle-aged
- **Appearance:** Self-described as having a "handsome majestic" reflection, "moonlit pool" eyes, physique of "a woman in her second trimester" (per his kids), "hobo-homeless" fashion (holey jeans and shirts). Not described in detail -- he sees himself as a hero, others see a schlub.
- **Personality:** Paranoid, melodramatic, grandiose self-image, surprisingly tender underneath. Terrible at remembering names (including his own children's). Addicted to sweets. His internal monologue is relentlessly literary and overblown.
- **Sprite needs:** Multiple poses for different locations (standing, crouching behind tree, clutching phone, holding coffee cup, holding bath bomb). Expressions: terrified, suspicious, righteous indignation, forced calm, sheepish/caught, smug, tender.
- **Note:** The narrator's visual design should contrast his self-image -- the player sees the schlub while the text describes the hero.

### The Wife / "The Terror" (Deuteragonist)

- **Role:** The narrator's wife, the "monster"
- **Age:** Middle-aged
- **Appearance:** Short (4'11" -- "two inches above dwarfism"), thick curly hair, wears glasses. Post-reveal: blood-red spork-shaped tail above her rear.
- **Personality:** Patient but sharp. Calls husband "idiot" (which he interprets as antiphrasis). Southern-born, uses food-based terms of endearment (honey, baby). Practical. Has mastered "judgmental silence."
- **Sprite needs:** Several expression sets. Expressions: neutral, concerned (left eyebrow), irritated (right eyebrow), eye roll, judgmental silence, "you're an idiot" face, shaking head, small sad smile (final scene).
- **Key detail:** The right eyebrow vs left eyebrow distinction is a running gag and should be visible in sprites.

### The Children (Supporting)

- **Role:** Two young adults (late teens/early 20s), names never remembered by narrator
- **Appearance:** One described as "fuzzy-headed." Otherwise vague -- the narrator literally can't be bothered.
- **Personality:** Sarcastic. Mock their father openly. Call him "dramatic" (mispronounced as "daddramatic" by one).
- **Sprite needs:** Minimal -- could be silhouettes or partial sprites since the narrator doesn't really "see" them as individuals. 2-3 expressions each.

### Oreo (Supporting)

- **Role:** The family dog, chaos agent
- **Appearance:** Black and white spotted Catahoula. Beady eyes.
- **Personality:** Oblivious. Digs holes. Runs between legs at the worst times. Fails at fetch. The narrator suspects him of being a double agent.
- **Sprite needs:** Dog sprite or small animated element. Digging pose, running pose, judgmental stare.

### Mother-in-Law (Voice Only)

- **Role:** Phone call only (Day 2.5)
- **No sprite needed.** Dialogue box with name label and phone filter on text/audio.

---

## 4. Locations

### 4.1 Bedroom

- **Usage:** Day 1, Day 1.5, Day 2.5, Day 3 (multiple scenes)
- **Description:** Standard suburban bedroom. Bed with excessive pillows (growing in number). Wooden nightstand (end table). Mirror on wooden dresser. Clothes baskets and hangers scattered (narrator placed them as "obstacles"). Dark at night, lit during day.
- **Variants:** Nighttime (dark, phone glow), daytime (natural light), close-up on bed/pillows.
- **Props:** Phone (911 pre-dialed), tape measure (yellow tongue), pillows (many), blankets.

### 4.2 Backyard / Porch

- **Usage:** Day 2
- **Description:** Suburban backyard. Back porch with seating. Tree line at the edge of the yard (narrator's hiding spot). Pine trees with branches. Oreo's hole in the dirt.
- **Variants:** Narrator's POV from behind tree (porch in distance), porch view.

### 4.3 Kitchen

- **Usage:** Day 3
- **Description:** Standard kitchen. Coffee maker. Refrigerator (sweets stashed on top). The path from kitchen to bedroom is the "minefield."
- **Variants:** Single view, possibly a hallway transition.

### 4.4 Bathroom

- **Usage:** Day 3 (climax)
- **Description:** Bathroom with bathtub, terracotta tile floor. Shower (with terry cloth towel). Bath bombs on tub edge. Broken coffee cup on floor. Mirror.
- **Variants:** Normal, post-towel-drop (tail reveal).

---

## 5. Scene Breakdown

### Day 1 -- First Dose

**Location:** Bedroom (and implied living room)
**Tone:** Establishing paranoia, comedic setup

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 1.1 | Journal Preamble | Narrator introduces himself and his situation. Psychiatrists, wife's medication, "for the good of humanity." Sets the melodramatic tone. |
| 1.2 | First Observation | Two minutes since "the pill." No physical changes. Describes wife. She sneezes -- he flinches. "Bless you." Eyebrow analysis begins (left = safe...or was). |
| 1.3 | Three Minutes | Heavy breathing gives him away. Wife asks "What's wrong?" He notices slightly more teeth. Narrator struggles to maintain composure. |

### Day 1.5

**Location:** Bedroom (nighttime)
**Tone:** Suspense parody, the tape measure mission

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 1.5.1 | She Sleeps, I Watch | Narrator watches sleeping wife. Phone clutched with 911 ready. Eloquent paranoid monologue about phones, Kurt Cobain, diabetic cats, and civic duty. |
| 1.5.2 | The Obstacle Course | Clothes basket slalom around the bed. Oreo snores -- narrator freezes. Dog described as blissfully unaware prey. |
| 1.5.3 | The Measurement | True purpose revealed: checking if wife grew tall enough to reach his sweets on top of the fridge. Tape measure extends along her body. 47...50...55...60 inches? Movement under blanket -- tape snaps back. "What are you doing?" "Measuring the mattress." "At 3 am? You're an idiot." |

### Day 2 -- Second Dose

**Location:** Backyard / Porch
**Tone:** Spy thriller parody, escalating absurdity

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 2.1 | Behind the Tree | Narrator hides behind pine tree observing wife on porch. Philosophical musings on immortality and pronouns. |
| 2.2 | The Children Arrive | Two youngest emerge. Narrator can't remember their names. They sit next to "their death." He decides to sacrifice them for knowledge and bandwidth. |
| 2.3 | Laughter | Expected screams never come. Trio laughs together. "Dad bit dramatic" / "Daddramatic." Narrator internally rages about idiom misuse and prepositions. |
| 2.4 | Oreo's Hole | Dog digs. Narrator wonders if it's an escape tunnel or his grave. Twig snaps underfoot. |
| 2.5 | "Honey?" | Wife calls out. Narrator tries to explain presence. "I am looking at the dog's hole." Judgmental silence. Wife asks for help "dressing the bed" -- he hears "dressing the dead." "Are there enough parts left to dress?" |

### Day 2.5

**Location:** Bedroom (nighttime)
**Tone:** The pillow conspiracy, escalating paranoia

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 2.5.1 | The Pillow Revelation | New sheets and pillows. Narrator realizes the ever-growing pillow collection is soundproofing for his screams. A years-long scheme predating the pill. |
| 2.5.2 | Terms of Endearment | "Honey" analysis. Baby = infants = missing children search on phone. The pet name hierarchy: #1 Baby, #2 Honey, #3 Idiot (which he believes is antiphrasis). |
| 2.5.3 | The Phone Call | Calls mother-in-law at 3am. "Did your daughter enjoy pillows as a child?" Explains the full conspiracy. Mother-in-law hangs up. Narrator blames his "rugged Spartan chin" for hitting end call. |
| 2.5.4 | Caught Again | Redialing, turns to check on wife -- she's sitting up, right eyebrow raised. "You're an idiot." "Just go to bed." He complies. |

### Day 3 -- Final Dose

**Location:** Bedroom -> Kitchen -> Bathroom
**Tone:** Climactic escalation, the coffee trial, the bath bomb standoff, the reveal

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 3.1 | The Berating Dance | Wife's rapid-fire lecture. Narrator nods and says "uh-huh" at intervals. Has lost ability to hear certain frequencies. Estimates duration by comparing to past arguments (longer than Browser History Explosion, shorter than Great Toilet Seat Debate). |
| 3.2 | "Are You Listening?" | Head keeps nodding after mouth stops moving. "Ummm...uh-huh." Billie Eilish ringtone ("bad guy") -- narrator hears it as a banshee's death herald. Doctor calls about infusions. |
| 3.3 | Iron Infusions | Wife explains iron infusions at doctor. Narrator interprets: iron = fortification = increasing the Beast's strength. "Better, stronger, faster. But apparently not taller." |
| 3.4 | The Coffee Ritual | The #1 Dad mug analysis (she uses HIS cup = she's calling him #2). The mantra: "three sugars, two creams" (which he reverses mid-walk). Precise pour to 0.42 inches from brim. Stir pattern: 3 left, 2 right, 3 left. Oreo interferes. Minefield walk back. |
| 3.5 | The Grading | Presents coffee. Wife sips. "I think you put too much cream and not enough sugar." Then: "It's fine." The word "fine" -- twice. Narrator concludes: apocalypse. |
| 3.6 | The Bath Bomb | Scans for weapons. Finds bath bomb. "A bomb." This will be his holy weapon against the apocalypse. Inner struggle -- he can't do it. He loves her. Drops the bath bomb. |
| 3.7 | The Tail | Oreo grabs bath bomb, collides with narrator's leg, pitches him forward into wife's coffee cup. Cup shatters. Towel falls. Wife bends to pick up cup shards. Narrator sees it: a blood-red, spork-shaped tail. |
| 3.8 | "You Were Right" | Wife acknowledges the tail. "The steroids? No, I haven't even started taking them yet." She took an aspirin. She's always been this way. Final three words, whispered: "You were right." The End. |

---

## 6. Art Requirements

### Character Sprites

| Character | Poses | Expression Count (est.) |
|-----------|-------|------------------------|
| Narrator / Husband | 4-5 (standing, crouching, clutching phone, holding cup, holding bath bomb) | 7-8 |
| Wife | 2 (standing, sitting/bed) | 8-9 (eyebrow distinctions important) |
| Child 1 | 1 (or silhouette) | 2-3 |
| Child 2 ("fuzzy-headed") | 1 (or silhouette) | 2-3 |
| Oreo (dog) | 2-3 (sitting, running, digging) | 2 |

### Backgrounds

| Background | Variants |
|------------|----------|
| Bedroom | 2 (night, day) |
| Backyard / Porch | 2 (from tree, porch view) |
| Kitchen | 1 |
| Bathroom | 1 |
| Hallway / Transition | 1 (optional) |

### CGs (Event Illustrations)

| CG | Scene | Description |
|----|-------|-------------|
| The Tape Measure | 1.5.3 | Narrator leaning over sleeping wife with tape measure extended, phone in other hand, 3am glow |
| Behind the Tree | 2.1 | Narrator pressed against pine tree, peeking around, wife visible on distant porch |
| The Coffee Offering | 3.4 | Narrator holding the #1 Dad mug with surgical precision, coffee at exactly 0.42 inches from brim |
| Bath Bomb Standoff | 3.6 | Narrator gripping bath bomb like a holy weapon, dramatic internal lighting |
| The Tail | 3.7 | Wife bent over picking up cup shards, blood-red spork-shaped tail visible, narrator's shocked POV |
| "You Were Right" | 3.8 | Wife's small sad smile, close-up, whispered words |

### Style Note

The art style should play the contrast: the narrator describes everything in gothic/epic terms, but the visuals show mundane suburban reality. This creates the comedy through visual irony. Consider a slightly exaggerated/cartoon style that can sell both the mundane truth and the narrator's dramatic framing.

---

## 7. Audio Requirements

### Music

| Track | Usage | Mood |
|-------|-------|------|
| Paranoia Theme | Day 1, general exploration | Tense strings over a suburban melody, slightly comedic |
| Nightwatch | Day 1.5, Day 2.5 (nighttime scenes) | Creeping suspense, tiptoeing energy, occasional comedic sting |
| Spy Mission | Day 2 (backyard) | Mock espionage, sneaking music |
| The Dance | Day 3 opening (berating scene) | Exhaustion waltz, ticking clock undertone |
| Coffee Ritual | Day 3 (coffee quest) | Ceremonial gravity, absurd reverence |
| The Apocalypse | Day 3 ("fine" x2, bath bomb) | Over-the-top dramatic swell |
| Tenderness | Day 3 (can't hurt her, drops bath bomb) | Genuine warmth breaking through comedy |
| The Reveal | Day 3 (tail, final moments) | Shock sting into quiet, eerie calm |

### Sound Effects

| SFX | Scene |
|-----|-------|
| Sneeze | 1.2 |
| Phone buzz / 911 screen glow | 1.5.1 |
| Dog snore/snarl | 1.5.2 |
| Tape measure extending (ratchet) | 1.5.3 |
| Tape measure snap/retract (whip crack) | 1.5.3 |
| Twig snap | 2.4 |
| Dog digging | 2.4 |
| Distant laughter | 2.3 |
| Phone ring (outgoing) | 2.5.3 |
| Phone disconnect tone | 2.5.3 |
| Billie Eilish-style ringtone | 3.2 |
| Coffee pour | 3.4 |
| Spoon stir (3-2-3 pattern) | 3.4 |
| Dog running past (scramble) | 3.4, 3.7 |
| Sip/slurp | 3.5 |
| Bath bomb drop (soft thud) | 3.6 |
| Cup shatter (ceramic on tile) | 3.7 |
| Towel drop (fabric whoosh) | 3.7 |

---

## 8. UI/UX Notes

- **Journal framing:** The entire game is a journal. Consider a journal-style text box or handwritten font overlay for section headers (Day 1, Day 1.5, etc.).
- **Text Animator heavy usage:** This game lives and dies on text presentation. Paranoid internal monologue needs emphasis tags, speed changes, dramatic pauses. "Everything." on its own line. "Damn." as a single beat. Ellipses that build tension.
- **Narrator vs Dialogue:** Clear visual distinction between internal monologue (journal narration) and spoken dialogue. Different text box style or position.
- **Comedy timing:** Punchlines need typewriter pauses before delivery. "What are you doing?" should hang before the scrambled excuse. "You're an idiot." needs a beat after the silence.
- **Visual contradiction:** When narrator describes himself as "handsome majestic," the sprite should show the opposite. When he describes wife as "the Terror," she should look like a normal tired mom.
- **Eyebrow system:** Wife's left vs right eyebrow raise is a recurring mechanic. Should be clearly distinct in sprites and possibly called out with a small UI indicator or Text Animator tag.

---

## 9. Design Decisions

| # | Decision | Status | Notes |
|---|----------|--------|-------|
| 1 | EF is the second VN to develop (after GITT) | Locked | Longer, more complex text presentation needs |
| 2 | Stack: Naninovel + Text Animator | Locked | Per toolkit GDD |
| 3 | Five-chapter structure matching journal days | Locked | Day 1, 1.5, 2, 2.5, 3 |
| 4 | Art style: mundane visuals contrasting epic narration | Proposed | Comedy depends on visual irony |
| 5 | Journal-style UI framing | Proposed | Handwritten headers, journal text box |
| 6 | Linear vs branching | Open | Source is linear; comedy doesn't need choices but player agency could enhance replay |
| 7 | Narrator voiced or unvoiced | Open | Internal monologue is the entire game -- voice acting could elevate or distract |
| 8 | Children as silhouettes vs full sprites | Open | Narrator doesn't register them as individuals; silhouettes reinforce this comedically |

---

**End of EF GDD**
