Perfect 👍
Here is a **clean, compact, copy-paste friendly REGEX CHEATSHEET (C# focused)** that you can **store for quick revision**.
I’ve organized it exactly the way your brain recalls things during exams/interviews.

---

# 📌 REGEX CHEATSHEET (C#) – QUICK REVISION

---

## 🔹 1. Most Used Regex Classes

```
.        → any character (except newline)
\d       → digit (0–9)
\D       → non-digit
\w       → letter, digit, underscore
\W       → non-word
\s       → whitespace (space, tab)
\S       → non-whitespace
```

---

## 🔹 2. Character Sets

```
[abc]        → a or b or c
[a-z]        → lowercase letters
[A-Z]        → uppercase letters
[0-9]        → digits
[a-zA-Z]     → letters
[^a-z]       → NOT lowercase letters
```

---

## 🔹 3. Quantifiers (CONTROL LENGTH)

```
*        → 0 or more
+        → 1 or more
?        → 0 or 1 (optional)
{n}      → exactly n times
{n,}     → n or more
{n,m}    → between n and m
```

📌 **Rule:** Character sets match **ONE character** unless quantifier is added.

---

## 🔹 4. Anchors (POSITION, NOT LENGTH)

```
^        → start of string
$        → end of string
\b       → word boundary
```

📌 **Validation ALWAYS needs ^ and $**

---

## 🔹 5. Grouping & Alternation

```
()       → capture group
(?: )    → non-capturing group
|        → OR
```

Example:

```
^(Mr|Ms|Mrs)\.?
```

---

## 🔹 6. Lookarounds (ADVANCED)

```
(?=x)    → positive lookahead
(?!x)    → negative lookahead
(?<=x)   → positive lookbehind
(?<!x)   → negative lookbehind
```

Example:

```
(?<!^)([A-Z])   → capital letter NOT at start
```

---

## 🔹 7. Escape Characters

```
\.  \+  \*  \?  \(  \)  \[  \]  \{  \}
```

📌 **Dot must be escaped to match literal dot**

---

## 🔹 8. C# Regex Methods (MEMORIZE)

```csharp
Regex.IsMatch()     // validation / contains
Regex.Matches()    // extraction
Regex.Replace()    // modification
Regex.Match()      // first match
```

---

## 🔹 9. Regex String Rule in C#

```
@"\d+"   ✅ correct (verbatim string)
"\\d+"   ❌ avoid unless necessary
```

📌 **Always use @"" with regex in C#**

---

## 🔹 10. Common Validation Patterns

### ✔ Only lowercase

```
^[a-z]+$
```

### ✔ Alphanumeric only

```
^[a-zA-Z0-9]+$
```

### ✔ Exactly 10 digits

```
^\d{10}$
```

### ✔ Indian Mobile

```
^[6-9]\d{9}$
```

### ✔ Email (basic)

```
^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$
```

---

## 🔹 11. Extraction Patterns

### Extract numbers

```
\d+
```

### Extract words

```
[a-zA-Z]+
```

### Extract hashtags

```
#[a-zA-Z0-9_]+
```

---

## 🔹 12. Replace / Modify Patterns

### Remove vowels

```
[aeiouAEIOU]
```

### Remove non-alphanumeric

```
[^a-zA-Z0-9]
```

### Normalize spaces

```
\s+
```

### CamelCase → snake_case

```
(?<!^)([A-Z])
```

Replacement:

```
_$1
```

---

## 🔹 13. Chunk String (Pairs)

```
..?
```

Example:

```
"abc" → ["ab", "c_"]
```

---

## 🔹 14. IPv4 (Strict)

```
^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)
(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}$
```

---

## 🔹 15. GOLD RULES (NEVER FORGET)

✔ Anchors → position
✔ Quantifiers → length
✔ Validation ≠ Extraction
✔ Regex doesn’t modify original string
✔ Spaces inside regex **matter**
✔ `\d` ≠ `\d+`
✔ `*` allows empty string

---

## 🎯 INTERVIEW ONE-LINERS

* **“^ and $ don’t limit length — quantifiers do.”**
* **“Regex.IsMatch checks existence, not full validity unless anchored.”**
* **“Lookarounds check conditions without consuming characters.”**

---

If you want next:

* Printable **PDF version**
* Cheatsheet **only for interviews**
* Regex **mistake checklist**
* Regex **debugging guide**

Just tell me 👍
