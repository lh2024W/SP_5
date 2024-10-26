using System.Net;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace SP_5
{
    class Program
    {
        static async Task Main()
        {
            //FTP клиент-сервер(при роботе с хостингом) port 21
            //FtpWebRequest


            //string ftpServer = "ftp://45.58.159.112/";
            //string userName = "liliyahach-001";
            //string password = ".@tNf4whMRAu2wG";
            //string filePathToDelete = "site1/file2.txt";

            //try
            //{
            //    Uri uri = new Uri(ftpServer + filePathToDelete);
            //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            //    request.Method = WebRequestMethods.Ftp.DeleteFile;
            //    request.Credentials = new NetworkCredential(userName, password);
            //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //    response.Close();
            //}
            //catch (Exception ex) { Console.WriteLine(ex.Message); }

            //string fileName = "newfile.txt";
            //string fileContent = "This is a new file content.";

            //try
            //{
            //    byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(fileContent);


            //    Uri uri = new Uri(ftpServer + fileName);
            //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            //    request.Method = WebRequestMethods.Ftp.UploadFile;
            //    request.Credentials = new NetworkCredential(userName, password);


            //    using (Stream requestStream = request.GetRequestStream())
            //    {
            //        requestStream.Write(fileBytes, 0, fileBytes.Length);
            //    }


            //    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //    Console.WriteLine($"File {fileName} created successfully.");
            //    response.Close();
            //}
            //catch (WebException ex)
            //{
            //    Console.WriteLine($"Error creating file: {ex.Message}");
            //}

            //string remoteDirectoryPath = "folder";
            //try
            //{
            //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + remoteDirectoryPath);
            //    request.Method = WebRequestMethods.Ftp.MakeDirectory;
            //    request.Credentials = new NetworkCredential(userName, password);


            //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //    {
            //        Console.WriteLine($"Directory created, status {response.StatusDescription}");
            //    }
            //}
            //catch (WebException ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            //string remoteDirectoryPath = "folder";
            //try
            //{
            //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + remoteDirectoryPath);
            //    request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            //    request.Credentials = new NetworkCredential(userName, password);


            //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //    {
            //        Console.WriteLine($"Directory deleted, status {response.StatusDescription}");
            //    }
            //}
            //catch (WebException ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            //try
            //{
            //    Uri uri = new Uri(ftpServer);
            //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            //    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            //    request.Credentials = new NetworkCredential(userName, password);


            //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //    {
            //        using (Stream responseStream = response.GetResponseStream())
            //        {
            //            using (StreamReader reader = new StreamReader(responseStream))
            //            {
            //                string line = reader.ReadLine();
            //                while (!string.IsNullOrEmpty(line))
            //                {
            //                    Console.WriteLine(line);
            //                    line = reader.ReadLine();
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}


            //string localFilePath = @"C:\Users\user\Desktop\flex.rar";
            //string remoteFileName = "flex.rar";

            //try
            //{
            //    using (FileStream fileStream = File.OpenRead(localFilePath))
            //    {
            //        Uri uri = new Uri(ftpServer + remoteFileName);
            //        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            //        request.Method = WebRequestMethods.Ftp.UploadFile;
            //        request.Credentials = new NetworkCredential(userName, password);


            //        using (Stream requestStream = request.GetRequestStream())
            //        {
            //            // Копируем содержимое локального файла в поток запроса
            //            fileStream.CopyTo(requestStream);
            //        }


            //        // Получаем ответ от FTP-сервера
            //        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            //        {
            //            Console.WriteLine($"File {remoteFileName} uploaded successfully.");
            //            Console.WriteLine($"FTP Response: {response.StatusDescription}");
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    Console.WriteLine($"Error uploading file: {ex.Message}");
            //}

            /////////////////////////////////////
            //t.me/FirstTest12365Bot
            //7732679670:AAFITsXBEZTQMIYtg2pyaiJ0uz_SzMrJSEE
            //https://core.telegram.org/bots/api

            //var botClient = new TelegramBotClient("7732679670:AAFITsXBEZTQMIYtg2pyaiJ0uz_SzMrJSEE");

            //var me = await botClient.GetMeAsync();
            //Console.WriteLine($"Hello, world! I am user {me.Id} and my name is {me.FirstName}");


            ////////////////////////////-------------ТЕЛЕГРАММ БОТ



            var botClient = new TelegramBotClient("7732679670:AAFITsXBEZTQMIYtg2pyaiJ0uz_SzMrJSEE");
            using var cts = new CancellationTokenSource();


            //Начало приема не блокирует поток вызова. Прием осуществляется в пуле потоков.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // получаем все типы обновлений
            };
            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            var me = await botClient.GetMeAsync();


            Console.WriteLine($"Бот под именем @{me.Username}, запущен.");
            Console.ReadLine();
            // Отправляем токен отмены для завершения работы бота
            cts.Cancel();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //это нужно для кнопочной клавиатуры
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                await HandleCallbackQuery(botClient, update.CallbackQuery);
            }
            //

            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;


            var chatId = message.Chat.Id;
            Console.WriteLine($"Получено сообщение: '{messageText}', в чате: {chatId}.");


            ////Отправка сообщения ботом в ответ
            //Message sentMessage = await botClient.SendTextMessageAsync(
            //    chatId: chatId,
            //    text: "Вы сказали:\n" + messageText,
            //    cancellationToken: cancellationToken);


            ////На сообщение пользователя, вопрос со ссылкой сайта
            //Message sentMessage = await botClient.SendTextMessageAsync(
            //chatId: chatId,
            //text: "А вы уже посещали наш сайт?!",
            //replyMarkup: new InlineKeyboardMarkup(
            //    InlineKeyboardButton.WithUrl(
            //        "Открыть",
            //        "https://google.com.ua/")),
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем стикер
            //Message sendMessage = await botClient.SendStickerAsync(
            //chatId: chatId,
            //sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"),
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем картинку с текстом
            //Message sendMessage = await botClient.SendPhotoAsync(
            //chatId: chatId,
            //photo: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"),
            //caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
            //parseMode: ParseMode.Html,
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем видео
            //Message sendMessage = await botClient.SendVideoAsync(
            //chatId: chatId,
            //video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
            //thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"),
            //supportsStreaming: true,
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем видео-сообщение
            //await using Stream stream = System.IO.File.OpenRead("/path/to/video-waves.mp4");

            //Message sendMessage = await botClient.SendVideoNoteAsync(
            //    chatId: chatId,
            //    videoNote: InputFile.FromStream(stream),
            //    duration: 47,
            //    length: 360, // value of width/height
            //    cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем аудио-сообщение
            //Message sendMessage = await botClient.SendAudioAsync(
            //chatId: chatId,
            //audio: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"),
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем фото
            //await using Stream stream = System.IO.File.OpenRead("/path/to/voice-nfl_commentary.ogg");
            //Message sendMessage = await botClient.SendVoiceAsync(
            //    chatId: chatId,
            //    voice: InputFile.FromStream(stream),
            //    duration: 36,
            //    cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем несколько фото
            //Message[] messages = await botClient.SendMediaGroupAsync(
            //chatId: chatId,
            //media: new IAlbumInputMedia[]
            //{
            //    new InputMediaPhoto(
            //    InputFile.FromUri("https://cdn.pixabay.com/photo/2017/06/20/19/22/fuchs-2424369_640.jpg")),
            //    new InputMediaPhoto(
            //    InputFile.FromUri("https://cdn.pixabay.com/photo/2017/04/11/21/34/giraffe-2222908_640.jpg")),
            //},
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем документ
            //Message sendMessage = await botClient.SendDocumentAsync(
            //chatId: chatId,
            //document: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"),
            //caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
            //parseMode: ParseMode.Html,
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем анимацию
            //Message sendMessage = await botClient.SendAnimationAsync(
            //chatId: chatId,
            //animation: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-waves.mp4"),
            //caption: "Waves",
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя обработка запросов (только для груповы чатов, нужен чатId)
            //Message pollMessage = await botClient.SendPollAsync(
            //chatId: "@group_or_channel_username",
            //question: "Did you ever hear the tragedy of Darth Plagueis The Wise?",
            //options: new[]
            //{
            //    "Yes for the hundredth time!",
            //    "No, who`s that?"
            //},
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем контакт
            //Message sendMessage = await botClient.SendContactAsync(
            //chatId: chatId,
            //phoneNumber: "+1234567890",
            //firstName: "Han",
            //lastName: "Solo",
            //cancellationToken: cancellationToken);


            ////на сообщение пользователя посылаем геолокацию
            //Message sendMessage = await botClient.SendVenueAsync(
            //chatId: chatId,
            //latitude: 50.0840172f,
            //longitude: 14.418288f,
            //title: "Man Hanging out",
            //address: "Husova, 110 00 Staré Město, Czechia",
            //cancellationToken: cancellationToken);


            //////создаем клавиатуру однолинейную
            //ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            //{
            //    new KeyboardButton[] { "Help me", "Call me ☎️" },
            //})
            //{
            //    ResizeKeyboard = true
            //};
            //Message sentMessage = await botClient.SendTextMessageAsync(
            //chatId: chatId,
            //text: "Choose a response",
            //replyMarkup: replyKeyboardMarkup,
            //cancellationToken: cancellationToken);


            //////создаем клавиатуру 4 кнопки
            InlineKeyboardMarkup inlineKeyboard = new(new[]
            {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "1.1", callbackData: "11"),
                InlineKeyboardButton.WithCallbackData(text: "1.2", callbackData: "12"),
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "2.1", callbackData: "21"),
                InlineKeyboardButton.WithCallbackData(text: "2.2", callbackData: "22"),
            }
            });
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "A message with an inline keyboard markup",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
            
        }


        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };


            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        static async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {
            //Выводим пользователю идентификатор нажатой клавиши (можно здесь обрабатывать и делать действия)
            await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, $"Вы выбрали: {callbackQuery.Data}");
            return;
        }
    }
}
