using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace BlazorGroupB.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int num { get; set; }
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public string errorMessage = "予期せぬエラーが発生しました";

        public string[] errorMainMessages = new string[]
        {
            "情報の取得に失敗しました",
            "Alertの表示に失敗しました",
            "スレッドの作成に失敗しました",
            "メッセージの作成に失敗しました",
            "UA情報の取得に失敗しました",
            "User情報の作成に失敗しました",
            "占いに失敗しました",
            "データベースとの接続に問題が発生しました",
            "ハブの接続情報の保持に失敗しました",
            "ハブの接続開始に失敗しました",
            "ハブのmsgデータの送信に失敗しました",
            "ハブリソースの解放に失敗しました"
        };

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string parameter)
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            if (errorMainMessages.Length >= num)
                errorMessage = errorMainMessages[num];
        }
    }
}