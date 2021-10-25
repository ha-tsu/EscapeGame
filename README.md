# EscapeGame
Ganbaru-zoi!!

## リモート環境の作り方
Githubにて
-  https://github.com/HarapekoClub/EscapeGame/ をFork 

ターミナルにて
-  cd 任意の作業ディレクトリ
-  git init
-  git remote add origin https://github.com/自分の名前/EscapeGame.git
-  git fetch
-  git merge origin/main
-  git checkout -b "feature/編集するシーン名"

Unity Hubにて
-  任意の作業ディレクトリを「リストに追加」
-  ※このときのUnityのバージョンが"2020.3.5f1"であることを確認(暫定)(あとで全員のバージョン合わせてそれでやる)

## 作業プロジェクトの更新の仕方
- ターミナルにて
- cd 作業ディレクトリ
- git fetch
- git merge origin/develop

Unityを開く

## 作業のアップロードの仕方
- cd 作業ディレクトリ
- git add .
- git commit -m "作業内容を簡潔に表すメッセージ"
- git push origin feature/編集シーン名(現在のブランチ)

現在のブランチは git branch で確認可能
