using System;

public interface IFileDownloader
{
    void DownloadFile(string url);
}

public class FileDownloadService : IFileDownloader
{
    public void DownloadFile(string url)
    {
        Console.WriteLine($"Fazendo donwload do arquivo no site: {url}");
    }
}

public class FileDownloaderProxy : IFileDownloader
{
    private FileDownloadService _realService;
    private Dictionary<string, bool> _cache = new Dictionary<string, bool>();

    public void DownloadFile(string url)
    {
        if (_cache.ContainsKey(url))
        {
            Console.WriteLine("Arquivo já foi baixado. Usando cache.");
            return;
        }

        Console.Write($"Deseja baixar o arquivo do site {url}? (s/n): ");
        string resposta = Console.ReadLine()?.ToLower();

        if (resposta == "s" || resposta == "sim")
        {
            if (_realService == null)
            {
                _realService = new FileDownloadService();
            }
            _realService.DownloadFile(url);
            _cache[url] = true;
        }
        else
        {
            Console.WriteLine("Download cancelado pelo usuário.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IFileDownloader downloader = new FileDownloaderProxy();

        downloader.DownloadFile("http://sitedearquivos.com/arquivo1.zip");
        Console.WriteLine();

        downloader.DownloadFile("http://documentosdoPI.com/arquivo2.zip");
        Console.WriteLine();

        downloader.DownloadFile("http://sitedearquivos.com/arquivo1.zip"); 
    }
}