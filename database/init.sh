#!/usr/bin/env bash
set -e

SCRIPT_DIR="$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )"
ROOT_DIR="$(dirname "$SCRIPT_DIR")"

echo "Press \q to quit psql"
psql -h "localhost" -U postgres -d postgres -a -f "$ROOT_DIR/database/init.sql"