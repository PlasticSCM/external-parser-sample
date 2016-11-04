# external-parser-sample
A dumb, hand made, external parser for Plastic and Semantic only capable of creating "declarations trees" for 2 given files.

This sample code explains how to create a skeleton external parser to be used by Plastic SCM and SemanticMerge/SemanticDiff.

It is only able to parse the 2 files under the "sample" directory. It has a hardcoded "declaration tree" for each of the files.

It just serves to show how a very simple parser works as a basis to create real ones.

## How to use the parser from SemanticDiff

semanticmergetool.exe -s sample\source.code -d sample\destination.code -ep=codeparser.exe

## How to configure Plastic SCM to use an external parser

Create an externalparsers.conf under your plastic4 configuration directory as follows:

C:\Users\pablo\AppData\Local\plastic4>type externalparsers.conf
.code=C:\Users\pablo\wkspaces\semantic-external-parsers\codeparser\bin\debug\codeparser.exe
