# Genie in a Test Tube -- Game Design Document

**Developer:** TecVooDoo LLC
**Type:** Visual Novel
**Stack:** Naninovel + Text Animator (+ Dialogue System for shared logic)
**Source:** "Genie in a Test Tube" short story (~5,000 words)
**Dev Notes:** `How I outline a story_GENIE.txt` (author's process doc with research, name etymologies, outline evolution)
**Dev Priority:** 1 (first VN to develop)
**Estimated Playtime:** 30-60 minutes

**Document Version:** 0.2
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

Near-future sci-fi drama. A disabled veteran is recruited by a billionaire for an experimental procedure that promises to restore her legs and give her the child she always wanted. The true cost and nature of the procedure are far worse than advertised.

### Tone

Tense, dialogue-driven, slow-burn reveals. Starts clinical/professional, shifts to hopeful, then to horror and defiance. Ends on a bittersweet but triumphant note.

### Themes

- Bodily autonomy and consent
- Grief weaponized as obsession
- Survival and fierce motherhood
- The ethics of genetic engineering
- Finding family in unexpected places

### Setting

Near-future Earth (2068, based on marriage year 2052 + 16 years). Advanced technology (holographic displays, hoverchairs, nanite medicine) but grounded -- no aliens, no magic. The world is recognizable but upgraded. Tech is based on real research extrapolated 30-40 years (Arizona State nanite trials 2018, Tufts/Vermont xenobots, CRISPR gene editing, blastocyst complementation).

### 1001 Nights Symbolism

The entire story is built on Arabian Nights / Aladdin references. This layer should inform art direction, naming, and potential Easter eggs in the VN.

| Story Element | 1001 Nights Reference |
|---------------|----------------------|
| **GENIE** (Genetically Engineered Nanite Infused Embryo) | Genie/Jinn -- trickster who grants wishes with a cost |
| **LAMP** (Ligation And Mechanosynthetic Procedure) | Aladdin's magic lamp |
| **Hanna** Shazi | Hanna Diab -- the real person who told the Aladdin story to Antoine Galland |
| **Shazi** | "Fool" in Chinese (original Aladdin was set in China) |
| **Antoine** (ex-husband) | Antoine Galland -- French translator who added the Aladdin story to 1001 Nights |
| **Mataleli** Galanidi | "Deception" in Amharic + Galland reference |
| **Nightwick** Inc. | "Nights" + "wick" (lamp wick) |
| **Minyoti** (island) | "Wish" in Amharic |
| **1,001** centaurs | 1001 Nights |
| **3 wishes** motif | Mat ticks off 3 points; Hanna holds up 3 fingers |
| **Aladin** (baby) | Aladdin -- born from the lamp/genie |
| Mat as trickster Jinn | "If it sounds too good to be true" -- the Jinn's deception theme |
| "Rub your lamp" joke | Hanna unknowingly names the motif |
| "It's a magical place" | Mat describing the island (also an Agents of SHIELD Tahiti reference -- Hanna catches it) |

---

## 2. Story Summary

Hanna Shazi, a wheelchair-bound veteran with a dishonorable discharge, is invited to Nightwick Incorporated by its billionaire CEO, Mataleli Galanidi. He offers her two free procedures under a "Purple Heart" program: LAMP (spinal reconstruction to restore her legs) and GENIE (a nanite-based embryo procedure to give her a child -- something she lost the ability to have due to combat injuries).

Hanna is suspicious but desperate. She agrees. What she doesn't know: LAMP transforms patients into centaurs, and GENIE uses Mat's dead daughter's DNA to clone his child. Hanna is drugged, transported to a private island (Minyoti), and placed in an 11-month coma.

She wakes mid-delivery. The baby is a boy with red hair and green eyes -- Hanna's traits, not Mat's daughter's. Hanna is a genetic chimera (she absorbed her twin in the womb), and her second DNA set disrupted Mat's plan. Mat turns violent. The centaur medical staff protect Hanna and her newborn son, Aladin.

---

## 3. Characters

### Hanna Shazi (Protagonist)

- **Role:** Player-perspective character, voiced narration
- **Age:** Late 30s
- **Name origin:** Hanna Diab (the real storyteller who told the Aladdin tale to Antoine Galland). Shazi = "fool" in Chinese (original Aladdin was set in China). Irony: Hanna is no fool -- Mat is.
- **Appearance:** Red hair (straight), green eyes, fair skin. Both traits deliberately chosen as recessive (red/green recessive to blonde/brown dominant). In wheelchair (6 months old) initially. Post-LAMP: human upper body attached to black horse body (centaur).
- **Personality:** Fierce, sarcastic, guarded, survivor. Uses humor as armor. Quick temper but deeply vulnerable about her inability to have children.
- **Backstory:** 15-year military career. Injured by mortar shrapnel on a supply run when her CO ordered the convoy to leave her behind. Infection from delayed treatment led to full hysterectomy. Assaulted the CO with an IV pole after he visited her in the hospital (during the same call where her husband demanded a divorce). Dishonorably discharged. Never contested it. Born a chimera (absorbed twin in womb) -- has two sets of DNA, which is the key plot twist.
- **Sprite needs:** Wheelchair pose set, centaur pose set (post-reveal). Expressions: neutral, suspicious/slitted eyes, angry, smirking, tearful, screaming/pain, tender/maternal.

### Mataleli "Mat" Galanidi (Antagonist)

- **Role:** CEO of Nightwick Inc., primary dialogue partner
- **Age:** 50s-60s (built company 30 years ago)
- **Name origin:** Mataleli = "deception" in Amharic. Galanidi = reference to Antoine Galland (French translator of 1001 Nights). He is the story's Jinn -- the trickster who grants wishes at terrible cost.
- **Company name:** Nightwick = "Nights" (1001 Nights) + "wick" (lamp wick)
- **Appearance:** Deep sepia skin, closely cropped curly black hair (receding), amber eyes, thick horn-rimmed glasses. Silver suit with paisley embroidery. Holographic merlot tie (horse animation).
- **Personality:** Composed, charismatic, patient. Steepled-fingers energy. Mask of philanthropy hiding obsessive grief. Turns dangerous when his plan fails. Born into old money, used family wealth to build Nightwick.
- **Backstory:** His daughter was born a congenital amputee (no legs). Her mother died from cesarean complications. He built Nightwick Inc. to help her. She was the first patient and first failure -- died during an early version of the procedure 30 years ago. His daughter loved horses and wanted to "fly like a bird or run like the wind." Has been trying to bring her back ever since using cloned DNA.
- **Sprite needs:** Seated at desk, standing, kneeling beside Hanna, in surgical scrubs (Act 2). Expressions: composed smile, steepled fingers, sympathetic, shocked/mouth open, dangerous slits, enraged.

### Centaur Nurse (Supporting)

- **Role:** Delivers the baby, protects Hanna
- **Appearance:** Woman's upper body in surgical scrubs, spotted white and brown horse body, blue eyes, thick tail.
- **Key moment:** Kicks Mat across the room to protect the baby. "You will not hurt this child."
- **Sprite needs:** Centaur full body (behind-curtain reveal). Expressions: calm/professional, protective/fierce.

### Centaur Doctor (Supporting)

- **Role:** Monitors vitals, reveals the baby's unexpected traits
- **Appearance:** Man's upper body in surgical scrubs and face mask, brown horse body.
- **Key moment:** "Uh, Sir. You need to see this."
- **Sprite needs:** Centaur full body. Expressions: calm, concerned/urgent.

### Baby Aladin (Non-speaking)

- **Role:** The newborn. Red-haired centaur boy.
- **Name origin:** Aladdin -- the boy born from the lamp and genie. Spelled "Aladin" in the final story, "Aladdin" in the first draft.
- **Visual only:** CG for the final scene -- baby with red hair wrapped in blankets, pony body visible. Shown in clear plastic dome bassinet.

---

## 4. Locations

### 4.1 Mat's Office

- **Usage:** Act 1 (majority of game)
- **Description:** Large executive office. Mahogany desk. Wall-length shelves behind the desk filled with frames and objects (including a picture of a red barn -- the holographic horse's "home"). Crystal chandelier with silhouette dolphins/mermaid projections on the high-pitched ceiling. Rich, corporate, slightly uncanny.
- **Variants:** Normal lighting. Possibly a dimmed/warm variant for emotional moments.
- **Props:** Holographic horse (animated -- runs on tie, jumps to barn picture), Mat's glasses (blue lenses with text lines, turn black when removed), touchpad device (black, green light), framed holographic photo of Mat's daughter (little blonde girl in princess costume, hoverchair with pink fairy wings, watching horses through fence).

### 4.2 Operating Room

- **Usage:** Act 2
- **Description:** Clinical, harsh lighting. Operating table with Hanna on her left side. IV pole. Large blue fabric curtain dividing the room at her midsection (hiding her new lower body). Surgical trays with metal tools. Monitors with readouts. Clear plastic dome bassinet.
- **Variants:** Pre-curtain-fall (curtain up, hiding centaur bodies), post-curtain-fall (full centaur reveal).

### 4.3 Transition/Black Screen

- **Usage:** Between acts (the "###" break in the source)
- **Description:** Black screen with muffled audio. Text conveying Hanna's disorientation -- sounds before sight. Gradual visual return (blur to focus).

---

## 5. Scene Breakdown

### Act 1 -- The Offer

**Location:** Mat's Office
**Tone:** Tense professional exchange, gradually revealing vulnerability

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 1.1 | Opening / Holographic Horse | Hanna distracted by tie. Horse animation jumps to barn picture. Establishes the sci-fi setting and Hanna's sharp personality. |
| 1.2 | Emergency Contact / Marital Status | Mat "discovers" Hanna is divorced. Hanna corrects to "Miss." Establishes Mat already knows more than he lets on. |
| 1.3 | The Purple Heart Program | Mat explains the free surgery offer. Hanna pushes back -- dishonorable discharge makes her ineligible. Mat clarifies no discharge stipulation. Hand-touch moment; Hanna threatens him. |
| 1.4 | Why Me? | Hanna demands reasons. Mat ticks off: injury, DNA compatibility, desire for children. Hanna's anger spikes -- corrects the medical details (hysterectomy, not just barren). Holds up middle finger. |
| 1.5 | The Question | Mat asks "What would you give for the chance to have children?" Hanna breaks down. "I would give anything." Mat's desk slap: "That's the right damn answer!" |
| 1.6 | Mat's Daughter | Mat shows the holographic photo of his daughter. Reveals she was a congenital amputee, died during an early procedure. Emotional pivot -- Mat becomes sympathetic. |
| 1.7 | LAMP and GENIE | Technical explanation of both procedures. Hanna's "rub your lamp" joke. Mat explains the island requirement. Hanna agrees to both. |
| 1.8 | The Touchpad | Hanna rubs the pad. Green light. Drugged. "I am suddenly very slee--" Fade to black. |

### Transition -- The Dark

**Location:** Black screen
**Tone:** Disorientation, dread

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| T.1 | Waking in Darkness | Muffled beeps, clacking (hooves). Hanna can't open eyes, can't feel body. Only head pain. Voices arguing about nerve block, contractions, cesarean. Gradual audio clarity. |

### Act 2 -- The Birth

**Location:** Operating Room
**Tone:** Horror, revelation, defiance, tenderness

| Scene | Summary | Key Beats |
|-------|---------|-----------|
| 2.1 | Mat's Confession | Mat tells Hanna where she is (island Minyoti), that LAMP worked, that she's been in a coma for 11 months, that she's about to give birth to "his" daughter. |
| 2.2 | Contractions | Pain waves. Strap snaps. Staff report dilation. Rising tension. |
| 2.3 | The Wrong Baby | Baby born. Staff alarmed -- red hair, green eyes, it's a boy. Mat's fury: "You did this." |
| 2.4 | Chimera Reveal | Hanna explains she absorbed her twin in the womb -- two sets of DNA. Mat's plan was always doomed. |
| 2.5 | Mat's Attack | Mat grabs scalpel, threatens baby. Hanna frees herself from straps. |
| 2.6 | Centaur Reveal | Nurse kicks Mat across room. Curtain falls. Hanna sees her own centaur body. Sees the centaur staff. Panic, oxygen mask, explanation: 1,001 centaurs on the island. |
| 2.7 | Meeting Aladin | Hanna holds her son for the first time. Names him Aladin. "Can I hold him?" Tender final CG. |

---

## 6. Art Requirements

### Character Sprites

| Character | Poses | Expression Count (est.) |
|-----------|-------|------------------------|
| Hanna (wheelchair) | 1 base | 7-8 |
| Hanna (centaur) | 1 base | 5-6 |
| Mat (office) | 2 bases (seated, standing/kneeling) | 6-7 |
| Mat (scrubs) | 1 base | 3-4 |
| Centaur Nurse | 1 base (full centaur) | 3 |
| Centaur Doctor | 1 base (full centaur) | 2-3 |

### Backgrounds

| Background | Variants |
|------------|----------|
| Mat's Office | 1 (normal lighting) |
| Operating Room | 2 (curtain up, curtain down) |
| Black/Transition | 1 (blur overlay) |

### CGs (Event Illustrations)

| CG | Scene | Description |
|----|-------|-------------|
| Holographic Horse | 1.1 | Horse leaping from tie across suit into barn picture |
| Daughter's Photo | 1.6 | Little blonde girl in princess costume, hoverchair, watching horses |
| The Touchpad | 1.8 | Hanna's hand on glowing green pad, eyes closing |
| Waking Up | T.1 | Hanna's blurred POV, harsh light, indistinct figures |
| Centaur Reveal | 2.6 | Curtain falls, Hanna sees her black horse body |
| Meeting Aladin | 2.7 | Hanna holding red-haired baby centaur, tears, smiling |

### UI Elements

- Holographic effects (tie horse, chandelier projections, glasses text)
- Touchpad prop
- Blue surgical curtain (animated fall?)

---

## 7. Audio Requirements

### Music

| Track | Usage | Mood |
|-------|-------|------|
| Office Tension | Act 1 general | Measured, clinical, slight unease beneath professionalism |
| Vulnerability | 1.4-1.5 (backstory, "anything") | Exposed, emotional, restrained |
| Mat's Grief | 1.6 (daughter story) | Melancholy, genuine sorrow |
| Hope/Agreement | 1.7-1.8 (agreement, touchpad) | Cautious optimism turning ominous |
| The Dark | Transition | Ambient dread, muffled, disorienting |
| Operating Room | Act 2 general | Clinical tension, beeping, urgency |
| Crisis | 2.3-2.5 (wrong baby, attack) | Alarm, danger, rapid escalation |
| Centaur Reveal | 2.6 | Shock, wonder, overwhelming strangeness |
| Aladin | 2.7 | Tender, warm, bittersweet resolution |

### Sound Effects

| SFX | Scene |
|-----|-------|
| Holographic shimmer/hum | 1.1 (tie horse) |
| Wheelchair brake clicks | Throughout Act 1 |
| Desk slap | 1.5, 1.8 |
| Touchpad beep + green light hum | 1.8 |
| Muffled beeping, hooves (clacking) | Transition |
| Heart rate monitor | Act 2 |
| Contraction pain stinger | 2.2 |
| Baby cry | 2.3+ |
| Metal crash (surgical tray) | 2.3 |
| Strap snap | 2.2 |
| IV pole swing / impact | 2.5 |
| Heavy kick + body hitting wall | 2.6 |
| Curtain fall (fabric whoosh) | 2.6 |
| Hooves on floor (clop clop) | 2.6-2.7 |

---

## 8. UI/UX Notes

- **Text Animator:** Use emotion tags for Hanna's anger (shake, emphasis), Mat's calm measured delivery (slow pacing), pain moments (distortion/jitter), tender moments (soft fade-in).
- **Typewriter pacing:** Mat speaks slowly and deliberately. Hanna speaks fast when angry, halting when vulnerable. Staff voices are clipped and professional.
- **Screen effects:** Blur/vignette for waking sequence (Transition). Flash white for contraction pain. Screen shake for Mat hitting the wall.
- **Choice points:** Linear with 1 cosmetic choice during the Transition (Hanna's waking thoughts). Both options converge to the same scene -- validates the choice system for future games without creating branching complexity.

---

## 9. Author's Outline vs Final Draft Notes

From `How I outline a story_GENIE.txt`. Key differences between the original outline and the finished story that may affect adaptation decisions:

- **Mat's fate:** Outline says centaurs "end up killing Mat." Final story has him kicked into a wall as "a bloody heap" -- ambiguous whether dead or unconscious. VN should preserve this ambiguity unless a design decision is made.
- **Observation window vs curtain:** Outline placed centaur staff behind an observation window. Final story uses the blue surgical curtain, which is more dramatic for the reveal. VN uses the curtain version.
- **Gender swap:** Story was originally about a disabled man. Changed to a woman when the GENIE acronym required an embryo/pregnancy plot. This is the final version.
- **"Tahiti" joke (Scene 1.7):** Hanna's "Tahiti?" response to "It's a magical place" is an Agents of SHIELD reference (Phil Coulson's recurring line). Mat doesn't get it. This is an intentional pop culture Easter egg.
- **Spelling: Aladin vs Aladdin:** First draft uses "Aladdin" (double-d), final story uses "Aladin" (single-d). VN should use whatever the author prefers -- flagged for confirmation.
- **11 months vs 10 months gestation:** Mat says "eleven months" in the final story (horse-human hybrid gestation). Outline says "10 months -- average gestation rate between a horse and human." Final story's 11 months is canon.

---

## 10. Design Decisions

| # | Decision | Status | Notes |
|---|----------|--------|-------|
| 1 | GITT is the first VN to develop | Locked | Shorter story, tighter structure, good first trial |
| 2 | Stack: Naninovel + Text Animator | Locked | Per toolkit GDD |
| 3 | Two-act structure matching source | Locked | Office (Act 1), Operating Room (Act 2), with transition |
| 4 | Linear with 1 cosmetic choice (transition waking) | Locked | Validates choice system; no branching complexity. Both options converge. |
| 5 | Unvoiced (architecture voice-ready) | Locked | Naninovel auto-voicing can be enabled later without script changes. |
| 6 | CG-only for centaur forms; standard sprites for human forms only | Locked | Centaur proportions don't work as VN sprites. CGs have more impact for reveals. |
| 7 | Script-first with placeholder prototyping | Locked | Industry standard. Full game playable with Naninovel placeholders before any art. |
| 8 | UTF-8 special characters directly in .nani files | Locked | TMPro renders Unicode natively. Validated in Phase 0 test script. |
| 9 | Default Naninovel paths for GITT | Locked | Reorganize for multi-game when starting game #2. |

---

**End of GITT GDD**
