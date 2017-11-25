DOCKER_ENV=''
DOCKER_TAG=''

case "$TRAVIS_BRANCH" in
   "master")
       DOCKER_ENV=production
       DOCKER_TAG=latest
     ;;
    "dev")
       DOCKER_ENV=dev
       DOCKER_TAG=dev
     ;;
esac

docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD

docker build -f ./src/MemoTime.App/MemoTime.Api/Dockerfile -t memo.time.api:$DOCKER_TAG ./src/MemoTime.App/MemoTime.Api --no-cache

docker tag  memo.time.api:$DOCKER_TAG $DOCKER_USERNAME/memotime.backend:$DOCKER_TAG

docker push $DOCKER_USERNAME/memotime.backend:$DOCKER_TAG
