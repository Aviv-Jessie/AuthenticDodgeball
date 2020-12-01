# AuthenticDodgeball
Dodgeball game


https://aviv-jessie.itch.io/assignment3



**tagline:Dodgeball game- try to hit me and keep moving**

<div dir='rtl' lang='he'>
  
  
## מהות המשחק
משחק מחניים שניתן לשחק בו שחקן יחיד \ מרובה משתתפים
המשחק מיועד לפלטפורמת המחשב, ויוגש כמשחק אינטרנטי
המשחק מיועד לכל גיל, בלי צורך בכישרון או ניסיון. משחק ספורטיבי מהנה
המשחק יכלול 2 סוגי משחקיות, שחקן יחיד ומרובה משתתפים- 2 שחקנים.
לקחנו את משחק המחניים הישן והאהוב והפכנו אותו לספורטיבי, תחרותי ומהנה הרבה יותר. 


## פרטי המשחק


### 1. מה רואים?

מסך המשחק מכיל מגרש מחנים, עם 5 שחקנים בכל קבוצה, והמשתמש רואה גבולות מסך ברורים שלא ניתן לעבור אותם. גבולות המסך הינם קו סיום המגרש
מעבר לגבולות המסך ישנם את הספסלים של השחקנים הפסולים, שיכולים לחזור למשחק בכל רגע נתון כאשר  השחקן שהפסיל אותם- נפסל בעצמו

  
### שני המסכים הראשונים
* מסך ראשי
* בחירת שלבים במצב משתמש יחיד..
  
## שרטוטים
![alt text](https://github.com/Aviv-Jessie/AuthenticDodgeball/blob/main/doc/figure_1.png?raw=true)
![alt text](https://github.com/Aviv-Jessie/AuthenticDodgeball/blob/main/doc/figure_2.png?raw=true)

### מסך בחירת המשחק
1. בחירת כמות שחקנים
2. אפשרות בחירת משחק- אדם מול אדם או אדם מול מחשב
3. אפשרות בחירת מגרש
4. הגדרות מפתחים: מצב סטורי הוא כניסה לסצנה בכל שלב עם הגדרות מפתחים אחרות

* AI is character behavior.
* character team is Which character(in tutorial have bullseye).

![alt text](https://github.com/Aviv-Jessie/AuthenticDodgeball/blob/main/doc/figure_4.png?raw=true)




### מסך המשחק
1. דמויות במשחק: ישנה אפשרות לבחור עד חמש דמויות. לחיצה על מספר במקלדת מעבירה את השליטה של המשתמש לדמות(הסבר נוסף בהמשך).
2. ניקוד במשחק: מופיע בחצי המסך של הקבוצה, לדוגמה - לקבוצה שבצד שמאל, אפס נקודות.
3. מתחת לניקוד קיימות האותיות אשר משמשות את השחקן ללחצן תפיסת הכדור (L\E)
4. דמויות השבוים במשחק, השחקנים הפסולים ברגע זה, יושבים על הספסל. (הסבר נוסף בהמשך..)
5. קהל
6. מצלמה עם שתי מצבים: מצב אחד בו התמקדות המצלמה במשחק בלבד. ומצב שני בו רואים את הקהל מריע.
7. הודעות\הסברים\התראות..

#### שליטה במשחק
בטלפונים/מחשבים עם מסך מגע הזזת הדמויות תיהיה על ידי drag and drop.
במחשב רגיל יהיה ניתן להזיז את הדמויות על ידי חצים במיקלדת.
השחקן שמשחק בצד הימני של המגרש ישתמש בחיצים ובמספרים בצד המקלדת (Num Lock)
במצב של משחק מרובה משתתפים, השחקן שמשחק בצד השמאלי של המגרש ישתמש במספרים ו WASD
מצב תפיסה יהיה על ידי לחיצה על כפתור במסך או במיקלדת. (כדוגמה מלעיל L\E)

> הדמויות נוצרו רנדומלית לצרוך המחשה על ידי האתר avatarmaker.com

![alt text](https://github.com/Aviv-Jessie/AuthenticDodgeball/blob/main/doc/figure_5.png?raw=true)

### 2. מה עושים?

המשחק מתחיל כאשר ישנן שתי קבוצות בשני צידי המגרש, ועל כל קבוצה לפסול את כל שחקני הקבוצה יריבה.
* תהליך ההתחלה של המשחק- בתחילת המשחק השחקנים מקבלים כדור לאמצע המגרש, עליהם לתפוס את הכדור ראשונים ולהתחיל בזריקה לעבר הקבוצה היריבה במטרה לפסול כמה שיותר שחקנים מהקבוצה היריבה. 
* תהליך הליבה של המשחק- על כל שחקן לתפוס את הכדור כאשר זורקים עליו, בעזרת מקש ייעודי לכך. ובהמשך לזרוק את הכדור על הקבוצה היריבה.
* תהליך הסיום של המשחק- בכדי לנצח על השחקן לפסול את כל שחקני הקבוצה היריבה, זאת אומרת שכאשר פוסל המשתמש את שחקני כל הקבוצה היריבה- ניצח
* מטרות שהשחקן צריך להשיג- פסילת כל שחקני היריב.

במהלך המשחק הפקדים שישתמש השחקן- מקלדת. מקשי חיצים, 2 מקשים לתפיסה ולזריקה ומקשי מספרים למעבר בין השחקנים.


הוסיפו תרשימים הממחישים את התהליכים השונים.


### 3. מה העצמים?



האובייקטים במשחק הינם- שחקנים וכדור. השחקנים צריכים לזרוק את הכדור על שחקני הקבוצה היריבה, ולחמוק מהכדור שזורקים עליהם.

החשקנים והכדור כאחד, שניהם עצמים חיוניים במשחק- ובלעדיהם לא ניתן להמשיך לשחק. השגת היעדים- ניצחון המשחק תלויה בשני עצמםים אלו.

עצם לא חיובי אך מסייע לשחקן- משאב, הוא הכדורים המיוחדים שעוזרים לשחקן לפסול את הקבוצה השניה בקלות

עצם ניטרלי שקיים במשחק הוא הקהל, אשר לא מועיל ולא מזיק לשחקנים.

המכשולים במשחק הם גבולות הגזרה והכדור


הוסיפו תרשימים של העצמים השונים.

### 4. מה האפשרויות?

במשחק הסינגל-פלייר, שחקן מול מחשב- ישנן 4 רמות קושי, כאשר ההבדלים בין הרמות הינם:

רמה 1: המחשב משחק ברמה נמוכה. 

רמה 2: רמת התפיסות של המחשב טובה יותר. 

רמה 3: רמת הזריקות של המחשב טובה יותר. 

רמה 4: שחקן המחשב זז מהר יותר ומתווסף כדור נוסף למגרש.


סוגי השחקנים שכנראה ישחקו במשחק הינם השחקנים התחרותיים והספורטיבים מכיוון שזה משחק ספורט תחרותי שכל המטרה של השחקן בו היא לנצח את היריב, בין אם הוא אדם או מחשב.

הוסיפו תרשים של מסך בחירת האפשרויות.

### 5. מה העולם?


המשחק מתרחש בסביבה סגורה, מגרש מחניים

עולם המשחק הינו עולם סגור

חוקי הפיסיקה במשחק הם החוקים ההגיונים לנו, כגון כוח המשיכה, חיכוך וכדומה..

הגבלת פעולות השחקן תתבצע ע"י חוקי הפיסיקה כמו- לא יוכל לעבור קיר

הוסיפו מפות ותרשימים של העולם.


### 6.	מה הסיפור?
* למשחק שלנו אין סיפור רקע, הרי זהו משחק ספורט תחרותי 

* עלילת המשחק הינה עלילה מתגברת אשר גרף הקושי עולה בהתאמה לרמות המשחק

הוסיפו תרשים המתאר את הקשת הדרמטית.

### 7.	מי הדמויות?


* הדמויות במשחק הינן דמויות אקראיות של שחקני מחניים
* לדמויות אין תכונות מיוחדות, אין להן תפקיד מיוחד, אלא רק דמות שחקן
* הדמויות המרכזיות במשחק הינן 2 הקבוצות, כאשר כל קבוצה מורכבת מחמישה שחקני מחניים
* דמויות המתנגדים הינם שחקני הקבוצה היריבה ואילו ה"גיבורים" הינם שחקני קבוצת הבית 

הוסיפו תרשימים של הדמויות.

## שלבים במשחק


במשחק הסינגל-פלייר, שחקן מול מחשב- ישנן 4 רמות קושי, כאשר ההבדלים בין הרמות הינם:

רמה 1: המחשב משחק ברמה נמוכה. 

רמה 2: רמת התפיסות של המחשב טובה יותר. 

רמה 3: רמת הזריקות של המחשב טובה יותר. 

רמה 4: שחקן המחשב זז מהר יותר ומתווסף כדור נוסף למגרש.

* כאשר בין כל שלב השינויים מתווספים.


## סקר שוק

נראה כאן משחקים דומים למשחק שלנו, כאשר חיפשנו במנועי החיפוש השונים את המילים:
Dodgeball, Dodge ball.
מצאנו 3 משחקים דומים לרעיון המשחק שלנו בשמות:

Dodgeball
Super Dodgeball
Super Dodgeball Advance

* צילומי מסך וקישורים:

![alt text](<a href="http://www.siz.co.il/"><img src="http://up419.siz.co.il/up2/zzod3dmnwtjm.jpeg" border="0" alt="WhatsApp Image 2020-12-01 at 20.21.53." /></a>)

https://apps.apple.com/il/app/stickman-1-on-1-dodgeball/id926245484





* בכדי שהמשחק שלנו יהיה שונה מקורי וטוב יותר ממשחקים אלו, ניצור במשחק אפשרות לכדורים מיוחדים כגון- 

כדורים מתפצלים, כדורים שנזרקים יותר מהר וכדומה..

שחקנים יעדיפו לשחק את המשחק שלנו ולא את משחקי היריבים מכיוון שאצלנו יש אפשרות למשחק מרובה משתתפים- שחקן נגד שחקן, ביחד על אותה מקלדת. מה שנותן אפשרות לשחק עם חבר ביחד.

בנוסף במשחק שלנו כמות הדמויות הינם 5על5 בעוד שבשאר המשחקים ניתן לשחק רק 1על1

במשחק שלנו יהיו Achievements
שאין במשחקים אחרים, מה שיגרום לשחקן לרצות לשחק עוד ועוד בכדי לאסוף ולקבל את כל ההשגים.






</div>
