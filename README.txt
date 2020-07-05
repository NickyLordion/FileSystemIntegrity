Russian:
Я прокомментировал весь код внутри, поэтому здесь я описываю процесс установки.

1. Откройте Командную строку с правами администратора.
2. Используйте 'cd', чтобы изменить каталог на C:\Windows\Framwork (Framework64, если ваша система x64)\v4.0.30319
3. Наберите InstallUtil.ехе 'литера диска':\Xr-Sec\Xr-Sec\bin\Debug\Xr-Sec.exe если вы клонируете репозиторий в корень диска 'литера'
4. Подождите, пока установка не закончится,чтобы вы могли запустить службу из Служб.
5. Служба запросит у вас отладку кода, и вы можете разрешить ей подключиться к JIT-отладчику вашей Visual Studio.

Возможно, позже я добавлю сюда еще какую-нибудь информацию. Наслаждайтесь моим проектом!
-------------------------------------------------------------------------------------
English:
Hello, now you're reading my README.txt.

I've commented all the code inside, so here I describe process of installation.

1. Open Command Prompt with administrative rights.
2. Use 'cd' to change directory to C:\Windows\Framwork(Framework64 if your system is x64)\v4.0.30319
3. Type InstallUtil.exe 'disk letteral':\Xr-Sec\Xr-Sec\bin\Debug\Xr-Sec.exe if you clone repository to the root of 'disk letteral'
4. Wait unil installation will end, so you can start service from Services.
5. It'll reqest you to debug code, and you can allow it to connect to your Visual Studio's JIT debugger.

Maybe I'll add any more information here later. Enjoy my project!
