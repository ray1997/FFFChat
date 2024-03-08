Every Friday since the announcement of ["Factorio: Space Age"](https://www.factorio.com/blog/post/fff-373) 

Factorio will announce the sort of blogpost/teaser of what's coming next on the next expansion.

Like one of many fans, I'm always hang around on #friday-facts on Factorio's Discord server.

But then, someone (can't remember their name, or find that exact message) mentioned something like "a chat lighten up every friday"

It got me curious on how much hype is it on every Friday.

So, given that I got too many free time, instead of growing my factory, I boot up [Discord Chat Exporter](https://github.com/Tyrrrz/DiscordChatExporter) and grabbing message from that channel.

Here's a snip of that message, without mentioning the person:

```csv
AuthorID,Author,Date,Content,Attachments,Reactions
"xxxxxxxxxxxxxxxxxx","name","2023-08-24T07:25:08.7300000+07:00","message","",""
.
.
.
.
"xxxxxxxxxxxxxxxxxx","name","2024-03-08T13:52:23.5100000+07:00","message","",""
```

A quick code, a slight help from [CSVHelper](https://github.com/JoshClose/CsvHelper), and [a few argument with ChatGPT](gpt_logs.md).

Here's a result:

```txt
Minutes before FFF | Percentage <-------------------> | Message count
-30 ##########---------------------------------------- 86
-25 ###############----------------------------------- 138
-20 ##########---------------------------------------- 93
-15 ############-------------------------------------- 112
-10 ##################-------------------------------- 165
-05 #########################------------------------- 227
000 ################################################## 448
005 #################################----------------- 295
010 ###################################--------------- 311
015 ###############################------------------- 281
020 ###############################------------------- 279
025 #############################--------------------- 258
030 ##################-------------------------------- 161
```
