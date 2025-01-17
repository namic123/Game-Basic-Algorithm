using System;

namespace Algorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 콘솔에서 커서를 보이지 않게 설정 (화면 출력이 깜빡이는 현상을 방지하기 위함)
            Console.CursorVisible = false;

            // 1초를 30프레임으로 나눈 시간(밀리초) => 프레임 간 대기 시간
            const int WAIT_TICK = 1000 / 30;
            const char CIRCLE = '\u25cf';
            // 마지막으로 실행된 프레임의 시간 저장
            int lastTick = 0;

            // 게임 루프 시작
            while (true)
            {
                /* 1. 프레임 시간 제어 */

                #region FPS Control

                // 현재 시스템의 시간을 가져옴 (밀리초 단위)
                int cuurentTick = System.Environment.TickCount;

                // 경과 시간이 설정된 대기 시간보다 적다면, 루프를 넘어감 (프레임 유지)
                if (cuurentTick - lastTick < WAIT_TICK)
                    continue;

                // 마지막 실행 시간을 현재 시간으로 갱신
                lastTick = cuurentTick;

                #endregion

                /* 2. 게임 루프의 주요 단계 */
                // 1. 입력 처리 (사용자 입력 관련 코드가 여기에 추가될 예정)

                // 2. 게임 로직 처리 (게임 상태 업데이트, AI 처리 등이 여기에 추가될 예정)

                // 3. 화면 렌더링
                // 커서를 콘솔 화면의 첫 번째 행, 첫 번째 열로 이동
                Console.SetCursorPosition(0, 0);
                // 콘솔 화면에 25x25 크기의 격자를 출력
                for (int i = 0; i < 25; i++) // 25행 반복
                {
                    for (int j = 0; j < 25; j++) // 각 행에 25개의 문자 출력
                    {
                        // 텍스트 색상을 녹색으로 설정
                        Console.ForegroundColor = ConsoleColor.Green;
                        // 유니코드 원형 문자를 출력
                        Console.Write(CIRCLE);
                    }

                    // 한 행의 출력을 완료한 후 줄바꿈
                    Console.WriteLine();
                }
            }
        }
    }
}