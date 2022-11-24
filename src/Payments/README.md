# Polestar.TB.Payments-back

Polestar.TB.Payments project description

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

Requires [dotnet](https://dotnet.microsoft.com/en-us/download/dotnet) and [MyGet](https://polestarjira.atlassian.net/wiki/spaces/DEV/pages/526778502/MyGet) setup

## Deploy to playground:

```
yarn build-local
```

```
sls deploy --stage playground --force
```

If you are using linux/wsl and have saved the aws credentials in the ~.aws/credentials file, you can deploy using this command.

```
sls deploy --stage playground --force --aws-profile playground
```

This assumes you have a named profile playground in the credentials file called playground, for example:

```
[default]
region=eu-north-1
aws_access_key_id = ...
aws_secret_access_key = ...
aws_session_token = ...

[playground]
region=eu-north-1
cli_pager=
aws_access_key_id = ...
aws_secret_access_key = ...
aws_session_token = ...
```
