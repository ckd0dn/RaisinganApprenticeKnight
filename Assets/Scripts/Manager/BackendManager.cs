using UnityEngine;

// 뒤끝 SDK namespace 추가
using BackEnd;

public class BackendManager : MonoBehaviour
{
    void Start()
    {
        var bro = Backend.Initialize(); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success

            Test();
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
        }
    }

    void Test()
    {
        BackendLogin.Instance.CustomLogin("user1", "1234"); // [추가] 뒤끝 회원가입 함수

        BackendGameData.Instance.GameDataInsert(); //[추가] 데이터 삽입 함수

        Debug.Log("테스트를 종료합니다.");
    }
}