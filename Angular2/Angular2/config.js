﻿System.config({
    defaultJSExtensions: true,
    transpiler: 'typescript',
    typescriptOptions: {
        emitDecoratorMetadata: true
    },
    map: {
        typescript: 'https://cdn.rawgit.com/robwormald/9883afae87bffa2f4e00/raw/8bca570a696c47a4f8dd03a52c98734676e94cea/typescript.js',
        'rx.all': 'https://cdnjs.cloudflare.com/ajax/libs/rxjs/3.1.1/rx.all.js',
    },
    paths: {
        app: 'src'
    },
    packages: {
        app: {
            main: 'main.ts',
            defaultExtension: 'ts',
        }
    }
});