from clients.base_http_client import BaseHttpClient

from config import settings


def get_all():
    with BaseHttpClient(settings.BACKEND_URL) \
            as client:
        test = client.get('default', verify=False)
        return test.json()


def get_by_id(entity_id: int):
    with BaseHttpClient(settings.BACKEND_URL) \
            as client:
        test = client.get(f'default/{entity_id}', verify=False)
        return test.json()


def show_terminal():
    while True:
        command = input('Enter command (type "help" for command list): ')

        if command == 'help':
            output = \
                'get_all :      get all entities\r\n' \
                'get_by_id :    get entity by id'
        elif command == 'get_all':
            output = get_all()
        elif command == 'get_by_id':
            entity_id = int(input('enter id: '))
            output = get_by_id(entity_id)
        elif command == 'exit':
            return

        print(output)


if __name__ == '__main__':
    show_terminal()
