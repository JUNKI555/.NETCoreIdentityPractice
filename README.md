# .NET Core Identity Practice
.NET Core Identity Practice Project

## need .NET Core SDK 3.1
https://docs.microsoft.com/ja-jp/dotnet/core/install/macos

## 作業メモ
- `git clone`
- `touch .gitignore`
- https://www.toptal.com/developers/gitignore
- change LICENSE
- `dotnet new mvc -o .`
- `dotnet run` で起動確認
- アプリケーションの `Dockerfile` 作成
- `dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p passward`
- `dotnet dev-certs https --trust`
- アプリケーションだけの `docker-compose.yml` を作成
- `docker-compose up -d` で動作確認

## 今回は実施してないメモ
- ディレクトリ構成
  - root
    - App
      - Dockerfile
      - docker-compose.yml
    - App.Tests
    - Dockerfile
    - App.sln
      - https://docs.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-with-dotnet-test

## 作業メモの作業メモ
- Stepを参考にDockerコンテナ立てる
  - HTTPS接続させるのにここ見なきゃかも
  - https://docs.microsoft.com/ja-jp/aspnet/core/security/docker-compose-https?view=aspnetcore-3.1
  - Dockerfile作成
  - https://docs.microsoft.com/ja-jp/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-3.1
- 同様にSwaggerいれる
- 同様にDapperもいれる
  - 簡単なデータベースアクセスもテストする
- Webエンジニア(仮)の備忘録 を参考に認証認可とSendGridでのメール認証いれる
  - https://techikoma.com/index.php/2020/06/05/asp-net-core-mvc/
  - https://techikoma.com/index.php/2020/06/11/identity-net-core/
  - ここも参照
    - https://docs.microsoft.com/ja-jp/aspnet/core/security/authentication/accconfirm?view=aspnetcore-3.1&tabs=visual-studio

