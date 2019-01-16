# Faster payment test project

# Before you run
1. Change PaymentDbConnection connection string in both AFS.Payment web.config and AFS.Payment.Test app.config. 
The last one uses DB connection for integration tests
2. Change BinCodesApiKey value in AFS.Payment web.config for some valid API key.
I was not able to get valid API key (even if could, 20 requests per day for testing, really?).
If API key is not changed, then API will always return error messages (by the way, different ones!).
For such case, there is AlwaysValidValidator prepared that always sucessfully validates any inserted card number. Inject it into PaymentController and rebuild.

# A comment
1. Everything lies in one MVC project, without splitting into several projects. It is done just for simplicity, as project is tiny.
