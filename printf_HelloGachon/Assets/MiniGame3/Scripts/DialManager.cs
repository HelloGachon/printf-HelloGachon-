using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialManager : MonoBehaviour
{
    public List<string> dialList;

    void Awake()
    {
        dialList = new List<string>();
        CreateData();
    }

    void CreateData()
    {
        dialList.Add("오늘은 함수에 대해 배워볼거야");
        dialList.Add("함수는 입력한 값을 처리해서 되돌려주는, 프로그램을 구성하는 가장 작은 단위라고 할 수 있어");
        dialList.Add("지금 보이는 함수는 정수 값을 입력받아 그 값에 1을 더해 돠돌려주는 함수야");
        dialList.Add("함수 이름은 addValue 이고");
        dialList.Add("정수로 입력 받은 값의 이름은 value, 이름 앞에 붙은 int는 이 값이 정수임을 뜻하지");
        dialList.Add("참고로 이렇게 함수가 입력받는 값을 인수 혹은 파라미터(parameter)라고 해");
        dialList.Add("{} 안에 작성된 내용은 이 함수가 입력받은 값을 어떻게 처리할지를 보여줘");
        dialList.Add("value 에 1을 더한 값을 다시 value 에 집어넣었어 이러면 입력받은 value 에 1이 더해진 상태지?");
        dialList.Add("함수에서 처리한 값을 되돌려줄 때는 return 과 함께 뒤에 돌려주고 싶은 값을 입력해주면 돼");
        dialList.Add("아, 그리고 코드의 마지막에는 꼭 세미콜론(;)을 붙이는 걸 잊지마");
        dialList.Add("함수의 이름 앞에 붙은 int 는 함수가 되돌려주는 값이 정수라는 뜻이야");
        dialList.Add("자, 설명을 들었으니 한 번 직접 함수를 작성해보자");
        dialList.Add("실수(float)형 값을 입력 받아 1을 뺀 후 되돌려주는 subValue 라는 이름의 함수를 작성해보자");
        dialList.Add("함수를 작성했다면 우측 상단의 실행 버튼을 누르렴");
        // dialList.Add("설명한 함수 아래에 main이라는 함수가 있지?");
        // dialList.Add("main 함수는 프로그램이 실행될 때 가장 처음으로 실행되는 함수이자 꼭 실행되는 함수야");
        // dialList.Add("main 함수가 끝나면 프로그램도 종료되게 돼");
        // dialList.Add("main 함수가 printValue 함수를 실행하도록 코드를 작성하고 인수로 1 을 입력했어");
        // dialList.Add("마지막에 보이는 return 0; ")
        // dialList.Add("자 이제 프로그램을 실행해 보자, 우측 상단의 실행 버튼을 눌러봐");
    }

    public string GetDial(int index)
    {
        return dialList[index];
    }
}
