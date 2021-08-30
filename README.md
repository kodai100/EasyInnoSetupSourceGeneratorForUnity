# 概要
UnityでビルドされたWindows用ソフトウェアのインストーラを簡易的に作成するためのツールです。

実際にインストーラーを生成は、[InnoSetup](https://jrsoftware.org/isinfo.php) を用いて行う必要があるため、このツールはInnoSetupに渡すための中間ファイル(.iss)を生成するツールと言い換えられます。

# 使用方法
本プロジェクトをビルドした後に生成されるexeファイルを、コマンドライン引数付きで呼び出します。

| Parameter | Value                                                | Required | Example                     | 
| --------- | ---------------------------------------------------- | -------- | --------------------------- | 
| 0         | リポジトリに付属するテンプレートファイルのパスを指定 | true     | C:\Users\user\Template.txt  | 
| 1         | .issファイルを出力するパスを指定                     | true     | C:\Users\user\sample.iss    | 
| -i        | アプリのUUIDを指定                                   | true     | com.kodai100.someapp        | 
| -n        | アプリの名称を指定                                   | true     | someapp                     | 
| -v        | アプリのバージョンを指定                             | false    | 1.0.0                       | 
| -p        | アプリのパブリッシャー名を指定                       | true     | kodai100                    | 
| -u        | アプリホームページのURLを指定                        | false    | https://kodai100.com        | 
| -e        | インストール後に展開されるアプリの.exeの名称         | true     | someapp.exe                 | 
| -r        | Unityでビルドしたアプリのディレクトリ                | true     | C:\Users\user\Build\someapp | 
| -o        | インストーラーを出力するディレクトリ                 | true     | C:\Users\user\Installer     | 
| -b        | 生成されるインストーラーの名称                       | true     | someapp_v1.0.0_setup        | 

```
$ EasyInnoSetupForUnity.exe C:\Users\user\Template.txt C:\Users\user\sample.iss -i com.kodai100.someapp -n someapp -v 1.0.0 -p kodai100 -u https://kodai100.com -e someapp.exe -r C:\Users\user\Build\someapp -o C:\Users\user\Installer -b someapp_v1.0.0_setup
```

# インストーラーの生成
InnoSetupをインストールし、パスにisccを追加します。

その後に、先程の工程で生成された`.iss`ファイルをisccへ渡します。

```
$ iscc C:\Users\user\sample.iss
```

`-o`で指定したディレクトリにインストーラが生成されます。