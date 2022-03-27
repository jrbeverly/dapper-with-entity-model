ARG VARIANT="6.0"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}

ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

ARG INSTALL_LIBRARY_SCRIPTS="false"
COPY library-scripts/ /tmp/library-scripts/
RUN if [ "$INSTALL_LIBRARY_SCRIPTS" = "true" ]; then bash /tmp/library-scripts/base.sh; fi \
    && apt-get clean -y && rm -rf /var/lib/apt/lists/* /tmp/library-scripts

RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends make build-essential libpq-dev postgresql-client
