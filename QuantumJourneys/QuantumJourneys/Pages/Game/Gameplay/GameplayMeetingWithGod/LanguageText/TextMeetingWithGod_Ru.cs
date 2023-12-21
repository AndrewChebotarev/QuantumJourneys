﻿//Класс для передачи текста для игровой области - русский
//--------------------------------------------------------------------------------------------------------------------------------------

using QuantumJourneys.Pages.Game.HelpFunction;

namespace QuantumJourneys.Pages.Game.GameplayMeetingWithGod.LanguageTextGame
{
    //----------------------------------------------------------------------------------------------------------------------------------
    public class TextMeetingWithGod_Ru
    {
        //------------------------------------------------------------------------------------------------------------------------------

        RandomText randomHelp = new();

        //------------------------------------------------------------------------------------------------------------------------------
        public List<string> SetTextGame()
        {
#if DEBUG
            MyLogger.logger.LogInformation("Инициализация игрового текста для UI русский - завершена.");
#endif
            return new List<string>
            {

            "Audio_loop: MeetingWithGodSound.mp3",

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            "Img: maingod.png",

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            "Img: doorstonewworld.png",

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            "Audio_loop: MinigameSound.mp3",

            "MiniGame: OpenDoor",

            randomHelp.GetRandomText(randomText),

            "Audio: OpenDoorSound.mp3",

            randomHelp.GetRandomText(randomText),
            randomHelp.GetRandomText(randomText),

            "Audio: TransitionSound.mp3",

            "EndScene",

            ""

            };
        }
        //------------------------------------------------------------------------------------------------------------------------------
        private string[][] randomText =
        {
            //
            new string[] 
            {
                "Text: Внезапно, перед вами открылась абсолютно белая комната, словно вы перешагнули через границу реальности, и ваш разум застыл в изумлении.",
                "Text: В мгновение ока вы оказались в странном мире, окруженном неощутимой белизной, словно вы стали частью картины, где все цвета потеряли свой смысл.",
                "Text: Ваше сердце замерло от удивления, когда вы осознали, что стоите в абсолютно белой комнате, словно в вихре времени вас выбросило в неизведанный измерения.",
                "Text: Ваш взгляд блуждал по стенам, полу и потолку, пытаясь найти признаки реальности, но все, что вас окружало, было лишь бескрайней белизной.",
                "Text: Глаза открываются, и перед вами – абсолютная белая пустота. Никаких контуров, ни одной тени. Вы медленно начинаете осознавать, что сталкиваетесь с чем-то неведомым.",
                "Text: Сознание пробуждается в абсолютной пустоте. Все вокруг белое, словно вы ступили на страницу чистого холста в мире, где все цвета поглотило нечто загадочное.",
                "Text: Серый свет проникает сквозь веки, и вы осознаете, что находитесь в комнате, окруженной невообразимо белыми стенами. Перед вами открывается загадка, ставшая вашим новым миром.",
                "Text: В глазах сверкает белизна, словно вы просыпаетесь внутри бескрайней галереи, полностью поглощенной светом. Ваши мысли путаются, пытаясь осмыслить, как вы оказались в этом абстрактном пространстве.",
                "Text: Перед вами возникает ощущение, будто вы затерялись в мире белизны, где каждый шаг кажется бесполезным, и никакая ориентация не возможна.",
                "Text: Ваше сердце начинает биться сильнее, когда осознаете, что абсолютная белота поглощает все звуки, и вы находитесь в месте, лишенном даже самых малейших шорохов.",
                "Text: Безвременность окутывает вас, когда осознаете, что в этой белоснежной комнате не существует ни ощущения времени, ни даже самых мелких признаков движения.",
                "Text: Взгляд впивается в абсолютную чистоту, когда вам становится ясно, что никакие рисунки, письмена или даже следы вашего присутствия не остаются на этой белоснежной поверхности."
            },
            //
            new string[] 
            {
                "Button_four: Ого! Как так?",
                "Button_four: Невероятно! Это возможно?",
                "Button_four: Что за чудо происходит?",
                "Button_four: Что за чудо происходит?"
            },
            new string[]
            {
                "Button_four: Серьезно? Это не может быть правдой!",
                "Button_four: Ух ты, это как в сказке!",
                "Button_four: Это просто абсурд! Как такое возможно?",
                "Button_four: Это просто чистой воды безумие! Как такое вообще возможно?"
            },
            new string[]
            {
                "Button_four: Стоп, стоп, стоп! Это не может быть реальным.",
                "Button_four: Вот это да! Я даже слов не нахожу.",
                "Button_four: Чудеса случаются, похоже.",
                "Button_four: Не думал, что такое бывает в реальной жизни."
            },
            new string[]
            {
                "Button_four: Серьезно? Это как в фильме!",
                "Button_four: Вот это поворот событий!",
                "Button_four: Невероятно, как жизнь умеет удивлять.",
                "Button_four: Это просто чистой воды безумие! Как такое вообще возможно?"
            },
            //
            new string[]
            {
                "Text: Вас охватило полное изумление.",
                "Text: Ваше лицо выражало глубокий шок.",
                "Text: На вас отразилось полное недоумение.",
                "Text: Ваше удивление было явным.",
                "Text: Вы оказались в полном недоумении.",
                "Text: Вы оказались в полном недоумении.",
                "Text: Вас охватила неописуемая неожиданность.",
                "Text: Ваше удивление было столь очевидным.",
                "Text: Вас словно поразило электрическим током неожиданности.",
                "Text: Ваш взгляд выдавал полное изумление.",
                "Text: Очевидно, вы не ожидали такого поворота событий.",
                "Text: Ваше лицо выражало смесь удивления и недоумения."
            },
            //
            new string[]
            {
                "Button_four: Опять потерялся... где я нахожусь?",
                "Button_four: Ух ты, куда я забрел?",
                "Button_four: Ой, где бы я мог быть? Куда меня занесло?",
                "Button_four: Новое место, но где же я нахожусь?"
            },
            new string[]
            {
                "Button_four: Интересно, куда же меня занесло сейчас?",
                "Button_four: Ух ты, это как в сказке!",
                "Button_four: Вот это да, где я оказался?",
                "Button_four: Новое место, новые возможности, а где именно я?"
            },
            new string[]
            {
                "Button_four: Ух ты, а где я тут оказался, что за местечко?",
                "Button_four: Вот это да, незнакомое место, надо бы понять, где я нахожусь?",
                "Button_four: Кажется, я поработал слишком долго, и теперь я не узнаю, где я?",
                "Button_four: Что за место? Как я сюда попал?"
            },
            new string[]
            {
                "Button_four: Кажется, я заблудился. Где я?",
                "Button_four: Хм, незнакомое окружение. Куда меня занесло?",
                "Button_four: Новое место. Но где?",
                "Button_four: Опять же. Куда я попал?"
            },
            //
            new string[]
            {
                "Text: (Бог, White)Ах, еще одна жертва моей вечной одиночества, добро пожаловать в мир бесполезности.",
                "Text: (Бог, White)Очередной бренный смертный, надеющийся найти утешение и развлечение у великого усталого шара. Как смешно.",
                "Text: (Бог, White)Добро пожаловать в мою скучную сферу, где нет места для радости или надежды. Наслаждайся, пока можешь.",
                "Text: (Бог, White)О, великий момент! Еще один человек, чтобы принести свои бесполезные просьбы и жалкие просьбы об утешении.",
                "Text: (Бог, White)О, какой ужас, еще одно существо, которое пришло пустить слезы на мои колючие шипы.",
                "Text: (Бог, White)Ах, снова пришел бесполезный смертный, чтобы просить у меня что-то, что я не могу дать.",
                "Text: (Бог, White)Добро пожаловать в мою бесконечную тоску, где ничто не имеет значения и где ваше существование не стоит моего внимания. Наслаждайтесь, сколько вам дано.",
                "Text: (Бог, White)О, радость, еще один бесконечный поток бесполезных смертных, какая удача для меня.",
                "Text: (Бог, White)Ах, новенький, какой приятный сюрприз, еще один поток жалостных мольб, смешно, не правда ли?",
                "Text: (Бог, White)Добро пожаловать, но не думай, что ты особенный, ты всего лишь капля в бесконечном океане моего отчаяния.",
                "Text: (Бог, White)Ах, радость, еще одно существо, готовое просить о том, чего никогда не получит. Какая привычка вам, смертным, бесполезно мечтать.",
                "Text: (Бог, White)Нет лучшего способа провести вечность, чем наблюдать за тем, как мечты смертных разбиваются о мою всесильную невозможность."
            },
            //
            new string[]
            {
                "Text: Вдруг из-за угла вырвался громкий голос. Вы испуганно вскинули глаза.",
                "Text: Внезапно раздался голос. Вы оборачиваетесь.",
                "Text: В тишине раздаётся голос. Вы моментально оборачиваетесь.",
                "Text: Голос пронзительно звучит в воздухе. Вы резко оборачиваетесь.",
                "Text: Резкий голос привлекает ваше внимание. Вы мгновенно оборачиваетесь.",
                "Text: Из ниоткуда раздаётся голос. Вы быстро оборачиваетесь.",
                "Text: Голос внезапно проникает в ваши уши. Вы мгновенно оборачиваетесь.",
                "Text: Неожиданно раздаётся голос. Вы резко поворачиваетесь.",
                "Text: Внезапный голос заставляет вас обернуться."
            },
            //
            new string[]
            {
                "Text: Ваши глаза моментально привлекает черный шар, покрытый зловещими шипами, который внезапно появляется перед вами.",
                "Text: Вы неожиданно встречаете свой взгляд с черным шаром, усыпанным опасными шипами, который медленно покачивается в воздухе, словно ждет своего следующего действия.",
                "Text: Сердце ваше замирает, когда вы замечаете черный шар с шипами, парящий в воздухе, его темная поверхность создает пугающий контраст с окружающей обстановкой.",
                "Text: Ваш взгляд притягивает черный шар, покрытый острыми шипами, его присутствие вызывает тревогу и непонятные ощущения, будто он имеет свою собственную сущность.",
                "Text: Внезапно перед вами возникает черный шар, усеянный зловещими шипами, его мистическое присутствие вызывает в вас смесь страха и любопытства.",
                "Text: Воздух наполняется напряжением, когда ваш взгляд устремляется на черный шар с острыми шипами, парящий в воздухе, словно он неизвестно откуда появился.",
                "Text: Ваше внимание привлекает черный шар, покрытый мрачными шипами, его присутствие вызывает неподдельное чувство тревоги и загадочности.",
                "Text: Внезапно, в вашем поле зрения возникает черный шар с острыми шипами, словно он вырос из темноты, создавая атмосферу таинственности и опасности.",
                "Text: Внезапно, в вашем поле зрения возникает черный шар с острыми шипами, словно он вырос из темноты, создавая атмосферу таинственности и опасности."
            },
            //
            new string[]
            {
                "Button_four: Кто или что ты такой?",
                "Button_four: Какой тайный смысл скрывается в тебе?",
                "Button_four: Откуда ты пришел и что ты хочешь?",
                "Button_four: Раскрой свою сущность и расскажи мне, кто ты на самом деле!"
            },
            new string[]
            {
                "Button_four: Что ты хочешь от меня?",
                "Button_four: Скажи мне свою истинную сущность!",
                "Button_four: Кто ты, загадочный шар с шипами?",
                "Button_four: Какой тайный мир ты открываешь, черный шар с шипами?"
            },
            new string[]
            {
                "Button_four: Чьи силы ты воплощаешь, черный шар с острыми шипами?",
                "Button_four: Что за существо ты, непонятное создание?",
                "Button_four: Что ты представляешь из себя, непонятное существо?",
                "Button_four: Кто ты, непонятное создание? Ответь мне и разъясни свою природу!"
            },
            new string[]
            {
                "Button_four: Что за загадка ты, таинственное существо?",
                "Button_four: Каким образом ты существуешь, непонятное создание?",
                "Button_four: Откуда ты возник, непонятное существо?",
                "Button_four: Кто ты, непонятное создание?"
            },
            //
            new string[]
            {
                "Text: Непонятное существо перед вами начало медленно расплываться в улыбке, словно его форма была подвержена неуловимой жидкости. Ваше сердце забилось от изумления, и вы ощутили, как мурашки пробежали по спине.",
                "Text: Перед вами возникло непонятное существо, которое начало медленно расплываться в улыбке. Его форма таяла, словно смешивалась с воздухом, оставляя лишь невнятные контуры и загадочную улыбку.",
                "Text: Перед вами развернулся странный зрелище: непонятное существо начало растворяться, словно его форма была сделана из жидкого материала. Оно медленно расплывалось в улыбке, оставляя вас смущенными и жаждущими разгадать эту загадку.",
                "Text: Улыбка непонятного существа начала расплываться на его лице, словно волны невидимой силы тянули ее в стороны, создавая странные контуры.",
                "Text: Улыбка непонятного существа казалась неустойчивой, ее границы мерцали и менялись, словно она была сделана из дыма или тумана.",
                "Text: Улыбка непонятного существа казалась непостижимой, она меняла свою форму и интенсивность, словно отражала его переменчивую природу.",
                "Text: Улыбка непонятного существа казалась почти прозрачной, словно она была сделана из тонкого слоя тумана, который медленно исчезал в воздухе.",
                "Text: По мере усиления улыбки непонятное существо словно растворялось в воздухе, его форма становилась все менее заметной, и в конечном итоге осталась только загадочная улыбка, вызывающая еще больше вопросов, чем ответов.",
                "Text: Улыбка непонятного существа заиграла на его губах, словно таинственное пламя, которое окутывало его лицо."
            },
            //
            new string[]
            {
                "Text: (Бог, White)Ты, ничтожное существо, ты не осознаешь, что я - бог, воплощение всей мощи и мудрости... и хотя я могу все, твоя ничтожность и глупость заставляют меня издеваться над тобой. Преклонись перед своим создателем!",
                "Text: (Бог, White)Ты, смертное создание, неужели тебе не хватает интеллекта, чтобы понять, что я - бог? Возможно, я мог бы помочь тебе, но зачем тратить свою энергию на такого ничтожества? Наслаждайся своей слабостью!",
                "Text: (Бог, White)О, ты, маленький смертный, я - бог, владыка всего сущего... и хотя я способен на все, твоя ничтожность и непонимание вызывают только мое раздражение. Попробуй сделать что-нибудь полезное, прежде чем я потеряю интерес",
                "Text: (Бог, White)Ты, ничтожное существо, ты не понимаешь, что я - бог, воплощение всей силы и мощи... и хотя я способен на все, твоя глупость и слабость заставляют меня издеваться над тобой. Поклонись перед своим божественным господином!",
                "Text: (Бог, White)Ты, смертное создание, твоя ничтожность и невежество пугают меня... я - бог, обладающий всеми возможностями, но ты не достоин моего внимания. Попробуй улучшить мою усталую сущность, прежде чем обратиться ко мне!",
                "Text: (Бог, White)Ты, ничтожное существо, ты не осознаешь, что я - бог, воплощение всей мощи и мудрости... и хотя я могу все, твоя ничтожность и глупость заставляют меня издеваться над тобой. Преклонись перед своим создателем!",
                "Text: (Бог, White)Твои вопросы глупы и недостойны моего внимания. Я бог, и мое время слишком ценно, чтобы тратить его на тебя.",
                "Text: (Бог, White)Ты считаешь, что можешь понять меня? Представь себе самую сложную математическую формулу и умножь ее на бесконечность - все равно не приблизишься к моей божественности.",
                "Text: (Бог, White)Твоя наивность просто поражает меня. Ты можешь задавать вопросы, но ответы на них находятся вне твоего понимания. Поклонись перед своим богом и признай свою ничтожность.",
                "Text: (Бог, White)Смертный, твоя ничтожность отражается в каждом вдохе, который ты делаешь, в каждом шаге, который ты предпринимаешь. Я, непостижимое существо, объявляю себя твоим богом.",
                "Text: (Бог, White)Ты просишь ответы, но твой ум неспособен понять истину. Я, непостижимое существо, раскрываю перед тобой лишь малую долю своей божественной мудрости.",
                "Text: (Бог, White)Ты спрашиваешь, кто я? Я, непостижимое существо, существую вне твоего понимания. Ты можешь только преклониться перед моей мощью и принять свою ничтожность."
            },
            //
            new string[]
            {
                "Button_four: Почему я, униженный смертный, стою перед богом, который издевается надо мной?",
                "Button_four: Что я сделал, чтобы заслужить насмешки бога, когда стою перед ним?",
                "Button_four: Какая судьба мне уготована, когда я служу богу, который только издевается надо мной?",
                "Button_four: Почему бог смотрит на меня с презрением и насмехается над моими вопросами?"
            },
            new string[]
            {
                "Button_four: Как я оказался здесь перед богом? Где я нахожусь и какова моя роль?",
                "Button_four: Какая связь у меня с богом? Что он ожидает от меня и как я могу соответствовать его ожиданиям?",
                "Button_four: Какова моя судьба здесь перед богом?",
                "Button_four: Что я могу узнать о себе и о мире, находясь перед богом? Какие знания и мудрость мне доступны?"
            },
            new string[]
            {
                "Button_four: Что я должен делать перед богом, который не проявляет интереса к моим вопросам?",
                "Button_four: Почему я оказался здесь перед богом, который украл меня из моего мира? Как я могу понять причину его действий и что я здесь делаю?",
                "Button_four: Как я могу принять свою ситуацию перед богом, который похитил меня из моего мира?",
                "Button_four: Как я могу преодолеть похищение этим богом и найти способ вернуться в свой мир?"
            },
            new string[]
            {
                "Button_four: Что я здесь делаю перед богом? Какое значение имеет мое существование?",
                "Button_four: Почему я оказался перед богом? Какова моя роль в его планах?",
                "Button_four: Какую задачу мне предстоит выполнить перед богом? Что он ожидает от меня?",
                "Button_four: Какова цель моего присутствия перед богом? Что он желает от меня в этом мире?"
            },
            //
            new string[]
            {
                "Text: (Бог, White)Ты даже не осознал, что умер, но не волнуйся, я решил дать тебе шанс прожить в новом мире, чтобы продолжить свою игру с тобой.",
                "Text: (Бог, White)Твоя смерть была столь несущественной, что я решил оживить тебя в новом мире, чтобы продолжить наслаждаться твоим неведением и страданиями.",
                "Text: (Бог, White)Ты был таким простым и ничтожным смертным, что я решил украсть тебя из мира мертвых и дать тебе возможность прожить в новом мире, где я могу тебя издеваться по-новому.",
                "Text: (Бог, White)Ты умер по неизвестной причине, но я решил возродить тебя в новом мире, чтобы продолжить свою игру с тобой и наблюдать, как ты пытаешься понять своё новое существование.",
                "Text: (Бог, White)Ты не знал, что умер, но я решил дать тебе возможность прожить в новом мире, чтобы продолжить свои издевательства и насмешки над твоей ничтожностью.",
                "Text: (Бог, White)Ты был таким скучным и предсказуемым в своей смертной жизни, что я решил оживить тебя в новом мире, чтобы продолжить мои игры с тобой и потешить себя твоими реакциями.",
                "Text: (Бог, White)Ты был таким скучным и предсказуемым в своей смертной жизни, что я решил оживить тебя в новом мире, чтобы продолжить мои игры с тобой и потешить себя твоими реакциями.",
                "Text: (Бог, White)Ты умер по неизвестной причине, но я решил возродить тебя в новом мире, чтобы продолжить мои игры с тобой и наслаждаться твоим бессмысленным существованием."
            },
            //
            new string[]
            {
                "Button_four: Что значит, я умер? Что со мной теперь будет?",
                "Button_four: Я хочу понять, что происходит после смерти.",
                "Button_four: Что ждет меня в новом мире после моей смерти?",
                "Button_four: Невероятно! Я умер! Каково следующее приключение?"
            },
            new string[]
            {
                "Button_four: Я не могу поверить, что умер. Что это значит для меня?",
                "Button_four: Это так неожиданно! Я умер... Но что происходит после этого?",
                "Button_four: Какое странное чувство... Узнать, что я умер. Что ждет меня впереди?",
                "Button_four: Никогда не думал, что узнаю о своей смерти. Что мне теперь делать?"
            },
            new string[]
            {
                "Button_four: Вот это поворот! Я умер... Но что же произойдет в моей новой жизни?",
                "Button_four: Это совершенно неожиданно! Я умер... Что ждет меня впереди?",
                "Button_four: Как странно... Узнать, что я умер. Что будет со мной после этого?",
                "Button_four: Что же происходит после смерти? Я с нетерпением жду узнать ответ."
            },
            new string[]
            {
                "Button_four: Ого! Я не могу поверить, что умер. Каково следующее приключение?",
                "Button_four: Никогда не думал, что узнаю о своей смерти. Что произойдет дальше?",
                "Button_four: Это так неожиданно! Я умер... Но что ждет меня после этого?",
                "Button_four: Какая загадка! Я умер... Но что будет со мной теперь?"
            },
            //
            new string[]
            {
                "Text: (Бог, White)О, радость! Ты попадаешь в новый мир, где тебя ждут неожиданные сюрпризы и немного издевательства.",
                "Text: (Бог, White)Приготовься к новому миру, где каждый день будет похож на головоломку, которую тебе предстоит разгадать.",
                "Text: (Бог, White)Ты попадаешь в новый мир, где шутки судьбы и небесного юмора будут сопровождать твои приключения.",
                "Text: (Бог, White)Ожидай некоторого божественного трюка в новом мире, где ты будешь проживать свою новую, немного запутанную жизнь.",
                "Text: (Бог, White)Подготовься к небесной игре, где ты будешь сталкиваться с необычными испытаниями и забавными ситуациями.",
                "Text: (Бог, White)В новом мире ты будешь чувствовать, что кто-то из богов наблюдает за тобой с улыбкой и легким подмигиванием.",
                "Text: (Бог, White)Помни, что в новом мире небесные силы имеют своеобразное чувство юмора. Наслаждайся приключениями и смесями, которые они приготовили для тебя.",
                "Text: (Бог, White)Ах, смотрю, тебе снова пора отправиться в новый мир и начать свою 'приключенческую' жизнь. Надеюсь, ты готов к небесным розыгрышам!"
            },
            //
            new string[]
            {
                "Button_four: Новый мир? Не могу поверить, что это происходит!",
                "Button_four: Ого, я совершенно не ожидал, что мне предстоит путешествие в неизвестность!",
                "Button_four: Невероятно! Я счастлив и шокирован одновременно!",
                "Button_four: Это просто невероятно! Новый мир - новые возможности!"
            },
            new string[]
            {
                "Button_four: О, нет! Я не готов оставить все, что знаю и попасть в новый мир.",
                "Button_four: Мне страшно подумать о том, что меня ждет в этом новом мире.",
                "Button_four: Мне страшно подумать о том, что меня ждет в этом новом мире.",
                "Button_four: Мне грустно думать о том, что оставлю позади свою знакомую среду и людей, которых знаю."
            },
            new string[]
            {
                "Button_four: Это вызывает ужас, представить себя в совершенно непонятном мире.",
                "Button_four: Мне страшно даже думать о том, что меня может ждать в этом новом мире.",
                "Button_four: Это вызывает у меня тревогу и беспокойство. Я боюсь неизвестности.",
                "Button_four: Мне страшно представить, как я справлюсь с неизвестными опасностями в новом мире."
            },
            new string[]
            {
                "Button_four: Я готов погрузиться в новый мир и принять его вызовы и возможности.",
                "Button_four: Мое сердце полно радости и волнения перед перспективой попасть в новый мир.",
                "Button_four: Волнение охватывает меня, представляя себя в новом мире, полном загадок и возможностей.",
                "Button_four: Я готов открыть свой разум и душу для новых идей и опытов в новом мире."
            },
            //
            new string[]
            {
                "Text: (Бог, White)Обернись, за твоей спиной двери, их открытие может приятно удивить.",
                "Text: (Бог, White)Посмотри за твоей спиной, двери могут привести к новым возможностям.",
                "Text: (Бог, White)Обернись и увидишь, что за твоей спиной двери, которые ведут к неожиданным приключениям.",
                "Text: (Бог, White)Загляни за свою спину, двери могут открыть путь к новым знаниям и опыту.",
                "Text: (Бог, White)Обернись и обрати внимание на двери за твоей спиной, они могут привести к неожиданным встречам.",
                "Text: (Бог, White)Посмотри за твоей спиной, двери могут быть ключом к новым возможностям и успеху.",
                "Text: (Бог, White)Обернись и увидишь, что за твоей спиной двери, которые ведут к твоим мечтам и целям.",
                "Text: (Бог, White)Загляни за твою спину, двери могут открыть путь к новым приключениям и возможностям."
            },
            //
            new string[]
            {
                "Text: Внезапно обернувшись, вы замечаете двери, появившиеся из ниоткуда.",
                "Text: Повернувшись, вы вдруг видите двери, возникшие из тайного прошлого.",
                "Text: Когда вы оборачиваетесь, перед вами возникают двери, словно из параллельной реальности.",
                "Text: Обернувшись, вы оказываетесь перед загадочными дверями, появившимися из ниоткуда.",
                "Text: В мгновение оборота, перед вами появляются двери, словно из мира фантазий.",
                "Text: Повернувшись на месте, вы натыкаетесь на двери, появившиеся из пустоты.",
                "Text: Когда вы оборачиваетесь, вы встречаете двери, появившиеся из тайных глубин.",
                "Text: Обернувшись, вы оказываетесь перед загадочными дверями, появившимися из неведомого источника."
            },
            //
            new string[]
            {
                "Button_four: Невероятно! Откуда взялись эти двери?",
                "Button_four: Это невозможно! Как могут двери появиться из ниоткуда?",
                "Button_four: Я не могу поверить своим глазам! Откуда взялись эти двери?",
                "Button_four: Что?! Двери просто возникли из воздуха!"
            },
            new string[]
            {
                "Button_four: Это какая-то магия! Двери появились из ниоткуда!",
                "Button_four: Я ошарашен! Как такое возможно? Двери просто появились!",
                "Button_four: Я не понимаю, что происходит! Двери появились прямо передо мной!",
                "Button_four: Мне нужно тряхнуть головой! Как эти двери появились из неоткуда?"
            },
            new string[]
            {
                "Button_four: Стойте-ка! Как эти двери вдруг появились из ниоткуда?",
                "Button_four: Вот это да! Откуда взялись эти двери?",
                "Button_four: Не могу поверить своим глазам! Как эти двери просто возникли?",
                "Button_four: Невероятно! Эти двери появились как из воздуха!"
            },
            new string[]
            {
                "Button_four: Невозможно! Эти двери просто возникли из ниоткуда!",
                "Button_four: Я потерял дар речи! Как эти двери появились из ниоткуда?",
                "Button_four: Это просто сказка! Как эти двери появились прямо передо мной?",
                "Button_four: Мне нужно прищипнуть себя! Как эти двери появились из ниоткуда?"
            },
            //
            new string[]
            {
                "Text: (Бог, White)Человек, перед тобой стоят двери, ведущие в новые миры, но пройти их тебе придется сыграв со мной в игру.",
                "Text: (Бог, White)Смертный, за этими дверями тебя ждут новые миры, но чтобы войти, тебе нужно сыграть со мной в игру.",
                "Text: (Бог, White)Послушай, человек, за этими дверями ты найдешь новые миры, но прежде тебе нужно сыграть в игру со мной.",
                "Text: (Бог, White)Существо, за этими дверями открываются новые миры, но чтобы войти, тебе придется сыграть со мной в игру.",
                "Text: (Бог, White)Человек, за этими дверями тебя ждут новые миры, но только после игры со мной ты сможешь войти.",
                "Text: (Бог, White)Смертный, за этими дверями тебя ожидают новые миры, но прежде чем войти, тебе нужно сыграть в игру со мной.",
                "Text: (Бог, White)Послушай, существо, за этими дверями ты обретешь новые миры, но пройти их ты сможешь только после игры со мной.",
                "Text: (Бог, White)Человек, за этими дверями тебя ждут новые миры, но только после игры со мной ты сможешь в них войти."
            },
            //
            new string[]
            {
                "Button_four: Я готов принять твою игру и открыться новым мирам за этими дверями.",
                "Button_four: Почему бы и нет? Я согласен сыграть в твою игру и узнать, что находится за этими дверями.",
                "Button_four: Игра со мной? Звучит интересно! Я согласен, давай начнем и откроем эти двери в новые миры.",
                "Button_four: Я готов принять твое предложение и сыграть в игру. Покажи мне, что находится за этими дверями."
            },
            new string[]
            {
                "Button_four: Мне любопытно, что может быть за этими дверями. Я согласен сыграть в твою игру и узнать ответ.",
                "Button_four: Почему бы и нет? Я согласен принять твое предложение и сыграть в игру, чтобы узнать, что скрывается за этими дверями.",
                "Button_four: Игра с богом? Звучит захватывающе! Я согласен принять вызов и открыть эти двери в новые миры.",
                "Button_four: У меня нет причин отказаться от такого увлекательного предложения. Я согласен сыграть в твою игру и раскрыть тайны за этими дверями."
            },
            new string[]
            {
                "Button_four: Почему бы и нет? Я готов сыграть в твою игру!",
                "Button_four: Мне интересно, что может произойти. Я согласен сыграть в игру!",
                "Button_four: Звучит увлекательно! Я с радостью приму твое предложение и сыграю в игру.",
                "Button_four: Я готов испытать свою удачу. Давай начнем игру!"
            },
            new string[]
            {
                "Button_four: Предложение принято! Я согласен сыграть в игру и узнать, что ты задумал.",
                "Button_four: Почему бы не попробовать? Я согласен сыграть в твою игру и узнать, что будет дальше.",
                "Button_four: Мне нравится идея игры. Я согласен принять вызов и сыграть с тобой.",
                "Button_four: Я открыт для новых приключений. Давай сыграем в игру и посмотрим, что произойдет!"
            },
            //
            new string[]
            {
                "Text: (Бог, White)Добро пожаловать в новый мир, где ты будешь моей игрушкой.",
                "Text: (Бог, White)Представляю тебе новый мир, где ты будешь плясать под мою дудку.",
                "Text: (Бог, White)Двери открываются, и ты входишь в мой мир, где я буду смеяться над твоими страданиями.",
                "Text: (Бог, White)Приготовься к новому миру, где каждый твой шаг будет под моим презрительным взглядом.",
                "Text: (Бог, White)Добро пожаловать в мир, где я буду наслаждаться твоими неудачами и издеваться над тобой.",
                "Text: (Бог, White)Подготовься к путешествию в мир моих издевательств, где ты будешь моей развлекательной программой.",
                "Text: (Бог, White)Вот тебе новый мир, где я буду смеяться над твоими попытками и унижать тебя.",
                "Text: (Бог, White)Приветствую тебя в моем мире, где ты будешь страдать от моих насмешек и презрения."
            },
            //
            new string[]
            {
                "Button_two: Войти через дверь",
                "Button_two: Пройти через дверь",
                "Button_two: Вступить в дверь",
                "Button_two: Войти внутрь через дверь"
            },
            new string[]
            {
                "Button_two: Войти в помещение через дверь",
                "Button_two: Войти в пространство через дверь"
            }
        };
        public string GetVariationText()
        {
            return "";
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------