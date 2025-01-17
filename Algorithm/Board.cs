using System;

namespace Algorithm
{
    class Board
    {
        // 맵을 저장할 2차원 배열 (타일 정보를 담음)
        public TileType[,] _tile;

        // 맵의 크기 (가로 및 세로 크기 동일)
        public int _size;

        // 화면에 출력할 유니코드 원형 문자 (타일을 시각적으로 표현)
        const char CIRCLE = '\u25cf';

        // 타일의 유형을 정의한 열거형 (Empty = 빈 공간, Wall = 벽)
        public enum TileType
        {
            Empty, // 빈 공간
            Wall   // 벽
        }

        // 맵 초기화 메서드
        public void Initialize(int size)
        {
            // 입력받은 크기로 2차원 배열을 생성
            _tile = new TileType[size, size];
            _size = size;

            // 맵의 각 타일을 초기화
            for (int y = 0; y < _size; y++) // 행 반복
            {
                for (int x = 0; x < _size; x++) // 열 반복
                {
                    // 가장자리는 모두 벽으로 설정
                    if (x == 0 || x == _size - 1 || y == 0 || y == _size - 1)
                        _tile[y, x] = TileType.Wall;
                    else
                        // 나머지 부분은 빈 공간으로 설정
                        _tile[y, x] = TileType.Empty;
                }
            }
        }

        // 맵을 콘솔에 출력하는 메서드
        public void Render()
        {
            // 현재 콘솔의 글자 색상을 저장 (나중에 복원하기 위함)
            ConsoleColor prevColor = Console.ForegroundColor;
            
            // 맵을 행(y)과 열(x)을 기준으로 출력
            for (int y = 0; y < _size; y++) // 행 반복
            {
                for (int x = 0; x < _size; x++) // 열 반복
                {
                    // 현재 타일의 유형에 따라 색상 설정
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
                    
                    // 원형 문자 출력 (타일 시각화)
                    Console.Write(CIRCLE);
                }

                // 한 행 출력 후 줄바꿈
                Console.WriteLine();
            }

            // 이전 콘솔 색상으로 복원
            Console.ForegroundColor = prevColor;
        }

        // 타일 유형에 따라 콘솔 색상을 반환하는 메서드
        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty: // 빈 공간은 녹색으로 표시
                    return ConsoleColor.Green;
                case TileType.Wall: // 벽은 빨간색으로 표시
                    return ConsoleColor.Red;
                default: // 기본적으로 녹색으로 설정
                    return ConsoleColor.Green;
            }
        }
    }
}
